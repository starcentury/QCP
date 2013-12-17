using RabbitMQ.Client;
using RabbitMQ.Client.Content;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QCP.MQ
{
    public class RabbitMQServices : IDisposable
    {        
        private Thread GetMessageThread;
        private const string exchange = "QCP";
        private const string routingKey = "QCP";
        private bool persistMode = true;
        private string QueueName;
        private string exchangeType = ExchangeType.Fanout;

        public delegate void OnMessageHandler(string message);
        public event OnMessageHandler OnMessage;

        public RabbitMQServices(string queueName)
        {
            QueueName = queueName;
        }

        public void Dispose()
        {
            if (GetMessageThread != null && GetMessageThread.ThreadState == ThreadState.Running)
            {
                GetMessageThread.Abort();
                GetMessageThread = null;
            }
        }

        public void Creat()
        { 
            ConnectionFactory cf = new ConnectionFactory();
           
            cf.HostName = "localhost";

            using (IConnection conn = cf.CreateConnection())
            {
                using (IModel ch = conn.CreateModel())
                {
                    if (exchangeType != null)
                    {
                        ch.ExchangeDeclare(exchange, exchangeType, true); // ,true,true,false,false, true,null); 
                        ch.QueueDeclare(QueueName, true, false, false, new Dictionary<string, object>()); 
                    }
                }
            }
        }

        public void SendMessage(string message)
        {
            ConnectionFactory cf = new ConnectionFactory();
            cf.HostName = "localhost";

            using (IConnection conn = cf.CreateConnection())
            {
                using (IModel ch = conn.CreateModel())
                {
                    ch.QueueBind(QueueName, exchange, routingKey, new Dictionary<string, object>());
                    
                    IBasicProperties basicProperties = ch.CreateBasicProperties();
                    ch.BasicPublish(exchange, routingKey, false,false, basicProperties, Encoding.UTF8.GetBytes(message));
                }
            }            
        }

        public void StartGetMessage()
        {
            GetMessageThread = new Thread(GetMessage);
            GetMessageThread.Start();
        }

        public void Stop()
        {
            if (GetMessageThread != null)
            {
                GetMessageThread.Abort();
                GetMessageThread = null;
            }
        }

        public void Pause()
        {
            if (GetMessageThread != null && GetMessageThread.ThreadState != ThreadState.Suspended)
            {
                GetMessageThread.Suspend();
            }
        }

        public void Resume()
        {
            if (GetMessageThread != null && GetMessageThread.ThreadState == ThreadState.Suspended)
            {
                GetMessageThread.Resume();
            }
        }

        public void GetMessage()
        {
            ConnectionFactory cf = new ConnectionFactory();
            cf.HostName = "localhost";

            using (IConnection conn = cf.CreateConnection())
            {
                using (IModel ch = conn.CreateModel())
                {
                    var subscription = new Subscription(ch, "QCP.Storage", false);

                    while (true)
                    {
                        BasicDeliverEventArgs basicDeliveryEventArgs = subscription.Next();
                        string messageContent = Encoding.UTF8.GetString(basicDeliveryEventArgs.Body);
                        if (OnMessage != null)
                            OnMessage(messageContent);
                        subscription.Ack(basicDeliveryEventArgs);

                        Thread.Sleep(1);
                    }
                }
            }                
        }
    }
}
