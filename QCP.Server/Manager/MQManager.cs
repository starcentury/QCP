using QCP.MQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Server.Manager
{
    public class MQManager : IDisposable
    {
        private RabbitMQServices iRabbitMQServices;

        public void Dispose()
        {
            if (iRabbitMQServices != null)
            {
                iRabbitMQServices.Dispose();
                iRabbitMQServices = null;
            }
        }

        public void Start()
        {
            iRabbitMQServices = new RabbitMQServices("QCP.Storage");
            iRabbitMQServices.OnMessage += iRabbitMQServices_OnMessage;
            iRabbitMQServices.StartGetMessage();
        }

        void iRabbitMQServices_OnMessage(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
