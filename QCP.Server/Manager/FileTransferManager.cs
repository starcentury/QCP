using Apache.NMS;
using Apache.NMS.ActiveMQ;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using Newtonsoft.Json;
using QCP.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Server.Manager
{
    public class FileTransferManager : IDisposable
    {
        private List<RequestToTransferFileMessage> _TransferFiles = new List<RequestToTransferFileMessage>();
        private LocalServer Server;
        private IMessageConsumer m_consumer;
        private QCP.MQ.RabbitMQServices iRabbitMQServices = new MQ.RabbitMQServices("QCP.Storage");
        
        public FileTransferManager(LocalServer server)
        {
            Server = server;            
        }        

        public List<RequestToTransferFileMessage> TransferFiles
        {
            get { return _TransferFiles; }            
        }

        public void AddTransferFile(RequestToTransferFileMessage msg)
        {
            msg.FileRecived +=msg_FileRecived;
            _TransferFiles.Add(msg);
        }

        void msg_FileRecived(string sessionID, string fileID, string path)
        {            
            iRabbitMQServices.SendMessage("QCP.Storage", path);
        }

        public void Dispose()
        {
            if (Server != null)
            {
                Server.Dispose();
                Server = null;
            }
        }
    }
}
