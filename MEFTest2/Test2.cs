using QCP.MQ;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFTest2
{
    [Export(typeof(IPlugin.IPlugin))]
    public class Test2 : IPlugin.IPlugin, IDisposable
    {
        private RabbitMQServices iRabbitMQServices;
        private RabbitMQServices iSystemRabbitMQServices;

        public void Dispose()
        {
            if (iRabbitMQServices != null)
            {
                iRabbitMQServices.Dispose();
                iRabbitMQServices = null;
            }
        }

        public bool Start()
        {
            //iRabbitMQServices = new RabbitMQServices("QCP.Data");
            //iRabbitMQServices.OnMessage += iRabbitMQServices_OnMessage;
            //iRabbitMQServices.StartGetMessage();
            //iSystemRabbitMQServices = new RabbitMQServices("QCP.System");
            return true;
        }

        void iRabbitMQServices_OnMessage(string message)
        {
            if (message != "")
            {
                //iSystemRabbitMQServices.SendMessage("QCP.System", message);
            }
        }
    }
}
