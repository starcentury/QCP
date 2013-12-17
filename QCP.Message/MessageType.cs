using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Message
{
    public class MessageType
    {
        public enum MessageTypeName
        {
            Auth = 0000,
            Storage = 0001,
            //文件传输消息类别 从1000开始
            RequestToTransferFileMessage = 1000,
            ApplyToTransferFileMessage = 1001,
            FileDataMessage = 1002,
            FileTransferComplete = 1003,
        }
    }
}
