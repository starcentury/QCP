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
        private string routingKey = "";
        private bool persistMode = true;
        private string QueueName;
        private string exchangeType = ExchangeType.Topic;

        public delegate void OnMessageHandler(string message);
        public event OnMessageHandler OnMessage;

        public RabbitMQServices(string queueName)
        {
            QueueName = queueName;
            routingKey = queueName;            
            Creat();
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
            ConnectionFactory cf = new ConnectionFactory() { HostName = "localhost" };

            using (IConnection conn = cf.CreateConnection())
            {
                using (IModel ch = conn.CreateModel())
                {
                    if (exchangeType != null)
                    {
                        Dictionary<string, object> args = new Dictionary<string, object>();                       
                        
                        ch.ExchangeDeclare(exchange, exchangeType, true); // ,true,true,false,false, true,null);                         
                        QueueDeclareOk result = ch.QueueDeclare(QueueName, true, false, false, args);
                        ch.QueueBind(QueueName, exchange, routingKey, args);                        
                    }
                    ch.Close();
                }
                conn.Close();
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                ConnectionFactory cf = new ConnectionFactory() { HostName = "localhost" };

                using (IConnection conn = cf.CreateConnection())
                {
                    using (IModel ch = conn.CreateModel())
                    {
                        Dictionary<string, object> args = new Dictionary<string, object>();

                        //ch.QueueBind(QueueName, exchange, routingKey, args);

                        IBasicProperties basicProperties = ch.CreateBasicProperties();

                        ch.BasicPublish(exchange, routingKey, false, false, basicProperties, Encoding.UTF8.GetBytes(message));
                        ch.Close();
                    }
                    conn.Close();
                }
            }
            catch
            {

            }
            finally
            {
                
            }
        }

        public void SendMessage(string _routingKey, string message)
        {
            ConnectionFactory cf = new ConnectionFactory() { HostName = "localhost" };

            using (IConnection conn = cf.CreateConnection()) 
            { 
                using (IModel ch = conn.CreateModel())
                {
                    Dictionary<string, object> args = new Dictionary<string, object>();

                    ch.QueueBind(QueueName, exchange, _routingKey, args);
                    
                    IBasicProperties basicProperties = ch.CreateBasicProperties();

                    ch.BasicPublish(exchange, _routingKey, false, true, basicProperties, Encoding.UTF8.GetBytes(message));
                    ch.Close();
                }
                conn.Close();
            }            
        }

        public void StartGetMessage()
        {
            //GetMessageThread = new Thread(GetMessage) { Name = "QCP.MQ", IsBackground = true };
            //GetMessageThread.Start();            
            Task a = new Task(new Action(GetMessage));            
            a.Start();            
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

        public Task<string> GetMessageAsync()
        {
            return Task.Run<string>(() => { return GetMsg(); });
        }

        public string GetMsg()
        {
            ConnectionFactory cf = new ConnectionFactory() { HostName = "localhost" };

            using (IConnection conn = cf.CreateConnection())
            {
                using (IModel ch = conn.CreateModel())
                {
                    while (true)
                    {
                        BasicGetResult result = ch.BasicGet(QueueName, false);
                        if (result != null)
                        {
                            string messageContent = Encoding.UTF8.GetString(result.Body);
                            ch.BasicAck(result.DeliveryTag, false);
                            return messageContent;                            
                        }
                    }
                }
            }   
        }

        public void GetMessage()
        {
            ConnectionFactory cf = new ConnectionFactory() { HostName = "localhost" };

            using (IConnection conn = cf.CreateConnection())
            {
                using (IModel ch = conn.CreateModel())
                {                    
                    while (true)
                    {
                        BasicGetResult result = ch.BasicGet(QueueName, false);
                        if (result != null)
                        {
                            string messageContent = Encoding.UTF8.GetString(result.Body);
                            if (OnMessage != null)
                                OnMessage(messageContent);

                            ch.BasicAck(result.DeliveryTag, false);                            
                        }

                        Thread.Sleep(1);
                    }                                    
                }                
            }                
        }
    }
}
