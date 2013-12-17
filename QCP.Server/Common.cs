using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Server
{
    public static class Common
    {
        public static void test(string message)
        {
            string URI = "tcp://localhost:61616/";
            IConnectionFactory factory;
            IConnection connection;
            ISession session;
            IMessageProducer producer;
            IMessageConsumer m_consumer;

            factory = new ConnectionFactory(URI);
            connection = factory.CreateConnection();
            connection.Start();
            session = connection.CreateSession();
            producer = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("QCP.Storage"));
            m_consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("QCP.Storage"));
            m_consumer.Listener += m_consumer_Listener;
            ITextMessage msg = producer.CreateTextMessage();
            msg.Text = message;

            producer.Send(msg, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);

            producer.Close();
            connection.Stop();
            connection.Close(); 
            //QCP.MQ.MessageServices s = new MQ.MessageServices("QCP.Storage", false);
            //s.ConnectToMQ();
            //s.CreateProducer();
            //s.SendMQMessage(message);
        }

        static void m_consumer_Listener(IMessage message)
        {
            System.Windows.Forms.MessageBox.Show(message.ToString());
        }
    }
}
