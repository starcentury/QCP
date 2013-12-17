using System;
using System.AddIn;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Authorize
{
    [AddIn("AuthorizeServices", Description = "Authorize Services", Publisher = "QCP", Version = "1.0.0")]
    public class AuthorizeServices : QCP.Plugin.AddinSideView.AddinSideView
    {
        private ISession session;
        private IMessageConsumer m_consumer;
        private MongoDatabase mydb;

        public bool Start()
        {
            return true;
        }


        public object MQSession
        {
            set { session = (ISession)value; }
        }
    }
}
