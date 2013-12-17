using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Message
{    
    public class StorageFileMessage : MessageBase
    {
        public StorageFileMessage()
        {
            this.MyType = MessageType.MessageTypeName.Storage;            
        }

        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileID { get; set; }
        /// <summary>
        /// 源文件路径
        /// </summary>
        public string SourceFilePath { get; set; }
    }

    public class StorageCompleteMessage : MessageBase
    {
        public StorageCompleteMessage()
        {
            this.MyType = MessageType.MessageTypeName.Storage;
        }

        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileID { get; set; }
        /// <summary>
        /// 存储中的ID
        /// </summary>
        public string StorageID { get; set; }
        /// <summary>
        /// 源文件路径
        /// </summary>
        public string SourceFilePath { get; set; }
    }
}
