using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Newtonsoft.Json;
using QCP.Plugin.HostSideView;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using System;
using System.AddIn.Hosting;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocket4Net;

namespace QCP.Server
{
    public partial class LocalServerController : Form
    {
        //WebSocket客户端
        private WebSocket iWebSocketClient;

        //连接中心服务器失败后重试的计时器
        private System.Windows.Forms.Timer RetryTimer;
        //在此秒数后开始重试连接中心服务器
        private int RetryAfterSeconds = 30;
        //重试连接的计数
        private int RetryCount = 0;
        //重试连接的读秒计数
        private int RetrySecondsTicks = 0;
        //是否正在重试连接中心服务器
        private bool IsTrying = false;
        //是否关闭窗体
        private bool IsClosed = false;
        //网络服务是否运行
        private bool IsRunning = false;
        //SuperSocket启动器
        private IBootstrap bootstrap;

        public LocalServerController()
        {
            InitializeComponent();
        }

        #region WebSocket
        /// <summary>
        /// 初始化WebSocket客户端,用来连接Center服务器.
        /// </summary>
        private void InitializationWebSocketClient()
        {
            iWebSocketClient = new WebSocket(String.Format("ws://{0}:{1}/", QCP.Server.Properties.Settings.Default.CenterURI, QCP.Server.Properties.Settings.Default.CenterPort));
            iWebSocketClient.Opened += iWebSocketClient_Opened;
            iWebSocketClient.Error += iWebSocketClient_Error;
            iWebSocketClient.MessageReceived += iWebSocketClient_MessageReceived;
            iWebSocketClient.DataReceived += iWebSocketClient_DataReceived;
            iWebSocketClient.Closed += iWebSocketClient_Closed;            
        }

        void iWebSocketClient_Closed(object sender, EventArgs e)
        {
            IsTrying = true;
        }

        void iWebSocketClient_DataReceived(object sender, WebSocket4Net.DataReceivedEventArgs e)
        {
            
        }

        void iWebSocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            QCP.NetworkDataModel.ModelBase model = JsonConvert.DeserializeObject<NetworkDataModel.ModelBase>(e.Message);

            switch (model.Category)
            {
                case NetworkDataModel.ModelBase.CategoryType.Client:                    
                    break;
                case NetworkDataModel.ModelBase.CategoryType.Server:
                    QCP.NetworkDataModel.Server server = JsonConvert.DeserializeObject<NetworkDataModel.Server>(e.Message);
                    if (server.IsAuth == true)
                    {
                        //如果本地服务器ID为空,则记录中心服务器分配的ID.
                        if (Properties.Settings.Default.ServerID == "" || Properties.Settings.Default.ServerID == null)
                        {
                            Properties.Settings.Default.ServerID = server.ID;
                            Properties.Settings.Default.Save();
                        }

                        this.lableCenterStatus.Text = "Center:Linked";

                    }
                    break;
                default:
                    break;
            }
        }

        void iWebSocketClient_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            if (e.Exception.GetType() == typeof(System.Net.Sockets.SocketException))
            {
                if ((e.Exception as System.Net.Sockets.SocketException).ErrorCode == 10061)
                {
                    IsTrying = true;                    
                }
            }
        }

        void iWebSocketClient_Opened(object sender, EventArgs e)
        {            
            QCP.NetworkDataModel.Server me = new NetworkDataModel.Server();

            if (Properties.Settings.Default.ServerID == "" || Properties.Settings.Default.ServerID == null)
            {
                me.ID = "";
            }
            else
            {
                me.ID = Properties.Settings.Default.ServerID;
            }

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            //iWebSocketClient.Send(string.Format("{0} {1}", "Register", me.ToJson()));  

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartObject();
                writer.WritePropertyName("Name");
                writer.WriteValue("");
                writer.WritePropertyName("ID");
                writer.WriteValue("");
                writer.WritePropertyName("IsAuth");
                writer.WriteValue(false);                 
                writer.WriteEndObject();
            }

            iWebSocketClient.Send(string.Format("{0} {1}", "Register", sw.ToString()));            
        }
        #endregion        

        #region Plugin

        private void LoadPlugin()
        {
            string path = Environment.CurrentDirectory;
            AppDomain currentDomain = AppDomain.CurrentDomain;

            string[] warnings = AddInStore.Update(path);

            //发现  
            var tokens = AddInStore.FindAddIns(typeof(HostSideView), path);

            foreach (var plugin in tokens)
            {
                ListViewItem item = new ListViewItem() { Text = plugin.Name };
                item.SubItems.Add(plugin.Description);
                item.SubItems.Add(plugin.Version);
                item.SubItems.Add(plugin.Publisher);
                item.SubItems.Add("OFF");
                item.Tag = plugin;
                
                //隔离和激活插件  
                AddInProcess process = new AddInProcess(Platform.X64);
                
                process.Start();

                HostSideView addin = plugin.Activate<HostSideView>(process, AddInSecurityLevel.FullTrust);
                
                if (addin.Start())
                {                    
                    item.SubItems[4].Text = "ON";
                }
                else
                {
                    item.SubItems[4].Text = "Error";
                }

                this.listView1.Items.Add(item);                
            }
        }

        #endregion

        /// <summary>
        /// 连接到中心服务器
        /// </summary>
        private void ConnectToCenter()
        {
            iWebSocketClient.Open();     
        }

        /// <summary>
        /// 设置RetryTimer的相关参数
        /// </summary>
        private void SetRetryTimer()
        {
            RetryTimer = new System.Windows.Forms.Timer();
            RetryTimer.Interval = 1000;
            RetryTimer.Tick += RetryTimer_Tick;            
        }

        /// <summary>
        /// 连接中心服务器失败后开始计时重试
        /// </summary>
        private void StartToRetryConnectToCenter()
        {
            SetRetryTimer();
            RetryTimer.Start();            
        }

        void RetryTimer_Tick(object sender, EventArgs e)
        {
            if (IsTrying)
            {
                if (RetrySecondsTicks == RetryAfterSeconds)
                {
                    IsTrying = false;
                    RetryCount++;
                    RetrySecondsTicks = 0;
                    RetryAfterSeconds = new Random(DateTime.Now.Millisecond).Next(30);//设置下一个重试秒数
                    this.lableCenterStatus.Text = "Retry to connect to center.";                    
                    ConnectToCenter();
                }
                else
                {
                    RetrySecondsTicks++;
                    this.lableCenterStatus.Text = String.Format("Retry after {0} Seconds", RetryAfterSeconds - RetrySecondsTicks);
                }
            }
        }

        private void LocalServerController_Load(object sender, EventArgs e)
        {            
            InitializationWebSocketClient();
            ConnectToCenter();
            StartToRetryConnectToCenter();
            LoadNetConfig();

            if (QCP.Server.Properties.Settings.Default.AutoStart)
            {
                StartLocalServer();
            }

            StartNetworkPerformance();
            
            LoadPlugin();            
        }

        private void StartLocalServer()
        {
            var result = bootstrap.Start();

            //如果启动成功,则设置按钮状态.如果失败,则提示信息.
            if (result == StartResult.Success)
            {
                IsRunning = true;
                //设置按钮状态
                this.toolStripButtonStart.Enabled = false;
                this.toolStripButtonStop.Enabled = true;
                //设置任务栏菜单状态
                this.startToolStripMenuItem.Enabled = false;
                this.stopToolStripMenuItem.Enabled = true;
                //提示信息
                this.labelStatus.Text = "Server Running.";

                Managers.iFileTransferManager = new Manager.FileTransferManager(bootstrap.AppServers.First() as LocalServer);
            }
            else
            {
                this.notifyIconMain.ShowBalloonTip(100, QCP.Server.Properties.Settings.Default.AppName, "Server Start Failed.", ToolTipIcon.Error);
            }
        }

        /// <summary>
        /// 停止服务器
        /// </summary>
        private void StopServer()
        {
            //判断服务器状态,如果正在运行则关闭.
            if (IsRunning)
            {
                bootstrap.Stop();
                IsRunning = false;
                //设置按钮状态
                this.toolStripButtonStart.Enabled = true;
                this.toolStripButtonStop.Enabled = false;
                //设置任务栏菜单状态
                this.startToolStripMenuItem.Enabled = true;
                this.stopToolStripMenuItem.Enabled = false;
                //提示信息
                this.labelStatus.Text = "Server Stoped.";

            }
        }

        /// <summary>
        /// 读取SuperSocket配置
        /// </summary>
        private void LoadNetConfig()
        {
            bootstrap = BootstrapFactory.CreateBootstrap();
            if (!bootstrap.Initialize())
            {
                this.notifyIconMain.ShowBalloonTip(100, QCP.Server.Properties.Settings.Default.AppName, "Failed to initialize network!", ToolTipIcon.Error);
            }
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            StartLocalServer();
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        #region System Performance
        
        private Thread ThreadOfNetworkPerformance;

        private void StartNetworkPerformance()
        {
            ThreadOfNetworkPerformance = new Thread(NetworkPerformanceResult);            
            ThreadOfNetworkPerformance.Start();
        }

        private void NetworkPerformanceResult()
        {
            while (true)
            {
                Thread.Sleep(1000);
                this.statusStripMain.Invoke(new Action(delegate()
                {
                    this.labelNetworkInInfo.Text = String.Format("bytes received:{0}k", SystemPerformance.NetworkReciveByte);
                    this.labelNetworkOutInfo.Text = String.Format("bytes sent:{0}k", SystemPerformance.NetworkSendByte);
                }));
            }
        }

        #endregion
        

        private void LocalServerController_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThreadOfNetworkPerformance.Abort();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string a = "test";
            object b = (object)a;
        }        
    }
}
