using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.AddIn;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.IM
{
    [AddIn("IMServices", Description = "IM Services", Publisher = "QCP", Version = "1.0.0")]
    public class IMServices : QCP.Plugin.AddinSideView.AddinSideView, IDisposable
    {
        private string URI = "tcp://localhost:61616/";
        private string TOPIC = "QCP.IM";
        private string USERNAME;
        private string PASSWORD;
        private IConnectionFactory factory;
        private IConnection connection;
        private ISession session;
        private IMessageProducer producer;
        
        public bool Start()
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
            session = connection.CreateSession();

            CreateProducer(true);
            return true;
        }

        private void CreateProducer(bool blnTopic)
        {
            if (blnTopic)
            {
                producer = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic(TOPIC));
            }
            else
            {
                producer = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(TOPIC));
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
