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

        private string MQName = "QCP.IM";
        private string USERNAME;
        private string PASSWORD;        
        private ISession session;
        private IMessageConsumer m_consumer;

        public bool Start()
        {
            try
            {
                m_consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic(MQName));
                m_consumer.Listener += m_consumer_Listener;
                return true;
            }
            catch
            {
                return false;
            }
        }

        void m_consumer_Listener(IMessage message)
        {

        }

        public void Dispose()
        {

        }


        public ISession MQSession
        {
            get { return session; }
            set { session = value; }
        }
    }
}
