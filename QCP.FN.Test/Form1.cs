using Apache.NMS;
using Apache.NMS.ActiveMQ;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using Newtonsoft.Json;
using QCP.Message;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocket4Net;

namespace QCP.FN.Test
{
    public partial class Form1 : Form
    {
        private WebSocket websocket;
        private int PackageSize = 1024 * 32;
        private List<RequestToTransferFileMessage> TransFiles;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            websocket = new WebSocket(this.textBox1.Text);
            websocket.ReceiveBufferSize = 4096;
            websocket.Opened += websocket_Opened;
            websocket.MessageReceived += websocket_MessageReceived;
            websocket.DataReceived += websocket_DataReceived;
            websocket.Error += websocket_Error;
            websocket.Open();
            //test();
        }        

        void m_consumer_Listener(IMessage message)
        {
            try
            {
                ITextMessage msg = (ITextMessage)message;

                if (msg != null)
                {
                    //StorageFileMessage RealMsg = (StorageFileMessage)msg.Body;
                    ////判断是否为存储消息
                    //if (RealMsg != null)
                    //{
                    //    //开始存储文件
                    //}

                    //以下为测试代码
                    //mongoDb服务实例连接字符串
                    MongoDatabase mydb;
                    string con = "mongodb://localhost:27017";
                    //得到一个于mongoDB服务器连接的实例
                    MongoServer server = MongoServer.Create(con);

                    //获得一个与具体数据库连接对象,数据库名为gywdb
                    mydb = server.GetDatabase("QCP");
                    
                    string path = msg.Text;

                    //定义一个本地文件的路径字符串
                    string localFileName = path;
                    //定义mongoDB数据库中文件的名称
                    string mongoDBFileName = Guid.NewGuid().ToString();
                    //设置GridFS文件中对应的集合前缀名
                    MongoGridFSSettings fsSetting = new MongoGridFSSettings() { Root = "fs" };
                    //实例化一个GridFS
                    MongoGridFS gridfs = new MongoGridFS(mydb, fsSetting);
                    //将本地文件上传到mongoDB中去,以默认块的大小256KB对文件进行分块
                    MongoGridFSFileInfo info = gridfs.Upload(localFileName, mongoDBFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void websocket_DataReceived(object sender, DataReceivedEventArgs e)
        {
            
        }

        void websocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            
        }

        void websocket_Opened(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate()
            {
                this.button1.Enabled = false;
                this.button2.Enabled = true;
            }));
        }

        void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            var o = JsonConvert.DeserializeObject<MessageBase>(e.Message);

            switch (o.MyType)
            {
                case MessageType.MessageTypeName.ApplyToTransferFileMessage:

                    ApplyToTransferFileMessage msg = JsonConvert.DeserializeObject<ApplyToTransferFileMessage>(e.Message);

                    Thread thread = new Thread(SendFile);
                    thread.Start(msg.FileID);
                    break;
                case MessageType.MessageTypeName.FileTransferComplete:
                    FileTransferCompleteMessage Message = JsonConvert.DeserializeObject<FileTransferCompleteMessage>(e.Message);

                    this.Invoke(new Action(delegate()
                    {
                        foreach (ListViewItem item in this.listView1.Items)
                        {
                            if (item.SubItems[1].Text == Message.FileID)
                            {
                                item.SubItems[5].Text = "OK";
                                break;
                            }
                        }
                    }));

                    break;
            }
        }

        private void SendFile(object fileID)
        {
            string FileID = fileID.ToString();

            RequestToTransferFileMessage file = TransFiles.Where(l => l.FileID == FileID).FirstOrDefault();

            if (file != null)
            {
                file.State = "Sending";

                this.Invoke(new Action(delegate()
                {
                    foreach (ListViewItem item in this.listView1.Items)
                    {
                        if (item.SubItems[1].Text == fileID.ToString())
                        {
                            item.SubItems[5].Text = "Sending";
                            break;
                        }
                    }
                }));

                DateTime sTime = DateTime.Now;

                while (file.PackageIndex < file.PackageCount)
                {
                    FileDataMessage Message = new FileDataMessage() { FileID = FileID, Data = QCP.Tool.FileTools.ReadFile(file.SourcePath, file.PackageIndex, PackageSize) };
                    this.SendMessage("FileData", Message);
                    file.PackageIndex++;

                    DateTime now = DateTime.Now;
                    TimeSpan PassTime = DateTime.Now - sTime;                    

                    this.Invoke(new Action(delegate()
                    {
                        foreach (ListViewItem item in this.listView1.Items)
                        {
                            if (item.SubItems[1].Text == fileID.ToString())
                            {
                                if (PassTime.TotalSeconds > 0)
                                {
                                    double c = file.PackageSize * file.PackageIndex;
                                    double b = file.FileSize;
                                    double a = c / b;
                                    
                                    double speed = ((file.PackageIndex * file.PackageSize) / (1024 * 1024)) / PassTime.TotalSeconds;
                                    string Speed = String.Format("{0} MB/s 已耗时:{1}秒", Convert.ToInt32(speed), PassTime.Seconds);

                                    item.SubItems[6].Text = a.ToString("0.00%");
                                    item.SubItems[7].Text = Speed;
                                }

                                break;
                            }
                        }
                    }));

                    Thread.Sleep(1);
                }                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var item in dlg.FileNames)
                {
                    FileInfo info = new FileInfo(item);
                    int PackageCount = QCP.Tool.FileTools.GetFilePackageCount(info.Length, PackageSize);

                    QCP.Message.RequestToTransferFileMessage msg = new Message.RequestToTransferFileMessage();
                                        
                    msg.FileID = Guid.NewGuid().ToString();
                    msg.PackageCount = PackageCount;
                    msg.PackageSize = PackageSize;
                    msg.SourcePath = info.FullName;
                    msg.FileName = info.Name;
                    msg.FileExtension = info.Extension;
                    msg.FileSize = info.Length;

                    SendMessage("RequestToTransferFile", msg);

                    TransFiles.Add(msg);
                    AddFileInfo(msg);
                }                
            }
        }

        private void AddFileInfo(RequestToTransferFileMessage msg)
        {
            ListViewItem item = new ListViewItem();
            item.Text = (this.listView1.Items.Count + 1).ToString();
            item.SubItems.Add(msg.FileID);
            item.SubItems.Add(msg.SourcePath);
            item.SubItems.Add(msg.FileName);
            item.SubItems.Add(msg.FileSize.ToString());
            item.SubItems.Add(msg.State);
            item.SubItems.Add("0%");
            item.SubItems.Add("0");

            this.listView1.Items.Add(item);
        }

        private void SendMessage(string kind, object msg)
        {
            if (websocket.State == WebSocketState.Open)
            {
                string Message = JsonConvert.SerializeObject(msg);
                websocket.Send(string.Format("{0} {1}", kind, Message));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TransFiles = new List<RequestToTransferFileMessage>();
            iRabbitMQServices.OnMessage+=iRabbitMQServices_OnMessage;
            iRabbitMQServices3.OnMessage += iRabbitMQServices3_OnMessage;
            iRabbitMQServices5.OnMessage += iRabbitMQServices5_OnMessage;
        }

        void iRabbitMQServices5_OnMessage(string message)
        {
            QCP.Message.RequestToTransferFileMessage msg = JsonConvert.DeserializeObject<QCP.Message.RequestToTransferFileMessage>(message);
            j++;
            this.listView2.Invoke(new Action(delegate()
            {
                this.listView2.Items[2].SubItems[1].Text = j.ToString();
                this.listView2.Items[2].SubItems[2].Text = msg.FileID;
            })); 
        }

        void iRabbitMQServices3_OnMessage(string message)
        {
            QCP.Message.RequestToTransferFileMessage msg = JsonConvert.DeserializeObject<QCP.Message.RequestToTransferFileMessage>(message);
            m++;
            this.listView2.Invoke(new Action(delegate()
            {
                this.listView2.Items[1].SubItems[1].Text = m.ToString();
                this.listView2.Items[1].SubItems[2].Text = msg.FileID;
            }));           
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            iRabbitMQServices.Creat();            
        }

        private QCP.MQ.RabbitMQServices iRabbitMQServices = new MQ.RabbitMQServices("QCP.Storage");
        private QCP.MQ.RabbitMQServices iRabbitMQServices2 = new MQ.RabbitMQServices("QCP.Storage");
        private QCP.MQ.RabbitMQServices iRabbitMQServices3 = new MQ.RabbitMQServices("QCP.Data");
        private QCP.MQ.RabbitMQServices iRabbitMQServices5 = new MQ.RabbitMQServices("QCP.Data");
        private QCP.MQ.RabbitMQServices iRabbitMQServices4 = new MQ.RabbitMQServices("QCP.Data");
        private int i, j, k, m, n;
        private Thread SendThread;

        private void button4_Click(object sender, EventArgs e)
        {
            iRabbitMQServices.StartGetMessage();
            iRabbitMQServices3.StartGetMessage();
            iRabbitMQServices5.StartGetMessage();    
        }

        private async void CallGetMessageAsync()
        {
            string result = await iRabbitMQServices.GetMessageAsync();
        }

        void iRabbitMQServices_OnMessage(string message)
        {            
            QCP.Message.RequestToTransferFileMessage msg = JsonConvert.DeserializeObject<QCP.Message.RequestToTransferFileMessage>(message);
         k++;
            this.listView2.Invoke(new Action(delegate()
            {
                this.listView2.Items[0].SubItems[1].Text = k.ToString();
                this.listView2.Items[0].SubItems[2].Text = msg.FileID;
            }));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SendThread = new Thread(SendMessage);
            SendThread.Start();
        }

        private void SendMessage()
        {
            while (true)
            {
                QCP.Message.RequestToTransferFileMessage msg = new RequestToTransferFileMessage() { FileID = Guid.NewGuid().ToString() };
                string msgSend = JsonConvert.SerializeObject(msg);
                iRabbitMQServices2.SendMessage(msgSend);
                iRabbitMQServices4.SendMessage(msgSend);
                i++;
                n++;
                this.listView2.Invoke(new Action(delegate()
                {
                    this.listView2.Items[0].Text = i.ToString();
                    this.listView2.Items[1].Text = n.ToString();
                    this.listView2.Items[2].Text = n.ToString();
                }));

                Thread.Sleep(1);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            iRabbitMQServices.Stop();
            iRabbitMQServices2.Stop();
            iRabbitMQServices3.Stop();
            iRabbitMQServices4.Stop();
            iRabbitMQServices5.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            iRabbitMQServices.Stop();
        }
    }
}
