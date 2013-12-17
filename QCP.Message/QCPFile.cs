using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QCP.Message
{ 
    public class RequestToTransferFileMessage : MessageBase
    {
        /// <summary>
        /// 文件接收完成代理方法
        /// </summary>
        /// <param name="sessionID">网络连接ID</param>
        /// <param name="fileID">文件ID</param>
        /// <param name="path">文件路径</param>
        public delegate void FileRecivedHandler(string sessionID, string fileID, string path);
        public event FileRecivedHandler FileRecived;
        private Thread WriteFileThread;
        private Queue<byte[]> _Data;

        public RequestToTransferFileMessage()
        {
            this.MyType = MessageType.MessageTypeName.RequestToTransferFileMessage;
            this.PackageIndex = 0;
            _Data = new Queue<byte[]>();
            this.State = "Waiting";
        }

        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileID { get; set; }
        /// <summary>
        /// 原始文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long FileSize { get; set; }
        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string FileExtension { get; set; }
        /// <summary>
        /// 源文件路径
        /// </summary>
        public string SourcePath { get; set; }
        /// <summary>
        /// 目标路径
        /// </summary>
        public string TargetPath { get; set; }
        /// <summary>
        /// 分包序号
        /// </summary>
        public int PackageIndex { get; set; }
        /// <summary>
        /// 分包数量
        /// </summary>        
        public int PackageCount { get; set; }
        /// <summary>
        /// 分包大小
        /// </summary>
        public int PackageSize { get; set; }
        /// <summary>
        /// 传输开始时间(在服务器端为接收开始时间)
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 传输状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 文件数据集合,用来存储文件分片数据,服务器端使用.
        /// </summary>        
        public Queue<byte[]> Data 
        {
            get
            {
                return _Data;
            }
        }

        public void AddData(byte[] data)
        {
            _Data.Enqueue(data);            

            if (WriteFileThread == null)
            {
                StartWriteFileThread();
            }

            if (WriteFileThread.ThreadState == ThreadState.Suspended)
            {
                WriteFileThread.Resume();
            }
        }

        private void StartWriteFileThread()
        {
            WriteFileThread = new Thread(WriteFile);
            WriteFileThread.Start();
        }

        private void WriteFile()
        {
            while (PackageIndex < PackageCount)
            {
                if (Data.Count > 0)
                {
                    var data = Data.Dequeue();

                    if (data != null)
                    {
                        FileStream fs = new FileStream("e:\\" + this.FileID + this.FileExtension, FileMode.OpenOrCreate, FileAccess.Write);
                        fs.Seek(PackageSize * PackageIndex, SeekOrigin.Begin);
                        fs.Write(data, 0, data.Length);
                        fs.Close();
                        this.PackageIndex++;
                    }
                    else
                    {
                        WriteFileThread.Suspend();
                    }
                }
                Thread.Sleep(1);
            }

            if (FileRecived != null)
            {
                FileRecived(SessionID, FileID, "e:\\" + this.FileID + this.FileExtension);
            }

            WriteFileThread.Abort();
        }
    }

    public class ApplyToTransferFileMessage : MessageBase
    {
        public ApplyToTransferFileMessage()
        {
            this.MyType = MessageType.MessageTypeName.ApplyToTransferFileMessage;
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

    public class FileDataMessage : MessageBase
    {
        public FileDataMessage()
        {
            this.MyType = MessageType.MessageTypeName.FileDataMessage;
        }

        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileID { get; set; }
        /// <summary>
        /// 文件数据
        /// </summary>
        public byte[] Data { get; set; }
    }

    public class FileTransferCompleteMessage : MessageBase
    {
        public FileTransferCompleteMessage()
        {
            this.MyType = MessageType.MessageTypeName.FileTransferComplete;
        }

        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileID { get; set; }
    }
}
