using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.MQ
{
    public class MessageServices : IDisposable
    {
        public bool IsRunning = false;
        private string URI = "tcp://localhost:61616/";
        private string MQName;
        private string USERNAME;
        private string PASSWORD;
        private bool IsTopic = false;
        private IConnectionFactory factory;
        private IConnection connection;
        private ISession session;
        private IMessageProducer producer;
        private IMessageConsumer m_consumer;
                
        public MessageServices(string mqName, bool isTopic)
        {
            IsTopic = isTopic;
            MQName = mqName;            
        }

        public void ConnectToMQ()
        {
            factory = new ConnectionFactory(URI);

            if (USERNAME != "")
            {
                connection = factory.CreateConnection(USERNAME, PASSWORD);
            }
            else
            {
                connection = factory.CreateConnection();
            }
            connection.Start();
            session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);

            IsRunning = true;
        }

        public void CreateProducer()
        {
            if (IsTopic)
            {
                producer = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic(MQName));
            }
            else
            {
                producer = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(MQName));
            }            
        }        

        public IMessageConsumer CreateConsumer()
        {
            if (IsTopic)
            {
                return session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic(MQName));
            }
            else
            {
                return session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(MQName));
            }
        }

        public void SendMQMessage(string strText)
        {
            ITextMessage msg = producer.CreateTextMessage();
            msg.Text = strText;
            producer.Send(msg, Apache.NMS.MsgDeliveryMode.NonPersistent, Apache.NMS.MsgPriority.Normal, TimeSpan.MinValue);
        }

        public void SendMQMessage(object obj)
        {
            IObjectMessage msg = producer.CreateObjectMessage(obj);
            producer.Send(msg, Apache.NMS.MsgDeliveryMode.NonPersistent, Apache.NMS.MsgPriority.Normal, TimeSpan.MinValue);
        }

        public void Dispose()
        {
        }
    }
}
