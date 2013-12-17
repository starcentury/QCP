using Newtonsoft.Json;
using QCP.Message;
using SuperWebSocket.SubProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Server.Command.FileTransfer
{
    public class RequestToTransferFile : SubCommandBase<LocalServerSession>
    {
        public override void ExecuteCommand(LocalServerSession session, SubRequestInfo requestInfo)
        {
            SystemPerformance.NetworkReciveByte += requestInfo.Body.Length;
            RequestToTransferFileMessage msg = JsonConvert.DeserializeObject<RequestToTransferFileMessage>(requestInfo.Body);

            if (msg != null)
            {
                ApplyToTransferFileMessage Message = new ApplyToTransferFileMessage() { FileID = msg.FileID, SourceFilePath = msg.SourcePath };
                session.Send(JsonConvert.SerializeObject(Message));

                msg.SessionID = session.SessionID;
                Managers.iFileTransferManager.AddTransferFile(msg);
            }
        }
    }
}
