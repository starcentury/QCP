using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Message
{
    [Serializable]
    public class MessageBase
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 消息类别
        /// </summary>
        public MessageType.MessageTypeName MyType { get; set; }
        /// <summary>
        /// 网络连接的ID
        /// </summary>
        public string SessionID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatTime { get; set; }

        public MessageBase()
        {
            this.CreatTime = DateTime.Now;
            this.ID = Guid.NewGuid().ToString();
        }
    }
}
