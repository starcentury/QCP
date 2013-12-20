using Newtonsoft.Json;
using QCP.Message;
using SuperWebSocket.SubProtocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
                Mutex mUnique = new Mutex(false, "WriteFile");
                mUnique.WaitOne();
                FileStream fs = new FileStream("e:\\" + msg.FileID, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                fs.Write(msg.Data, 0, msg.Data.Length);
                fs.Close();
                mUnique.ReleaseMutex();
            }
        }
    }
}
