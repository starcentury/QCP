using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private Timer RetryTimer;
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

        /// <summary>
        /// 初始化WebSocket客户端,用来连接Center服务器.
        /// </summary>
        private void InitializationWebSocketClient()
        {
            iWebSocketClient = new WebSocket("ws://" + QCP.Server.Properties.Settings.Default.CenterURI + ":" + QCP.Server.Properties.Settings.Default.CenterPort.ToString() + "/");
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

        void iWebSocketClient_DataReceived(object sender, DataReceivedEventArgs e)
        {
            
        }

        void iWebSocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            
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
            this.lableCenterStatus.Text = "Center Linked.";
        }

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
            RetryTimer = new Timer();
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
                    this.lableCenterStatus.Text = "Retry to connect to center.";                    
                    ConnectToCenter();
                }
                else
                {
                    RetrySecondsTicks++;
                    this.lableCenterStatus.Text = "Retry after " + (RetryAfterSeconds - RetrySecondsTicks).ToString() + " Seconds";
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
    }
}
