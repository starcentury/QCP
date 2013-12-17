using Newtonsoft.Json;
using QCP.Message;
using SuperWebSocket.SubProtocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Server.Command.FileTransfer
{
    public class FileData : SubCommandBase<LocalServerSession>
    {
        public override void ExecuteCommand(LocalServerSession session, SubRequestInfo requestInfo)
        {
            SystemPerformance.NetworkReciveByte += requestInfo.Body.Length;
            FileDataMessage msg = JsonConvert.DeserializeObject<FileDataMessage>(requestInfo.Body);

            if (msg != null)
            {
                if (Managers.iFileTransferManager.TransferFiles.Where(l => l.FileID == msg.FileID).FirstOrDefault() != null)
                {
                    Managers.iFileTransferManager.TransferFiles.Where(l => l.FileID == msg.FileID).FirstOrDefault().AddData(msg.Data);
                }
            }
        }
    }
}
