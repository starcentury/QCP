using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Logging;
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

namespace QCP.Center
{
    public partial class ServerController : Form
    {
        //是否关闭窗体
        private bool IsClosed = false; 
        //网络服务是否运行
        private bool IsRunning = false;
        //SuperSocket启动器
        private IBootstrap bootstrap;

        public ServerController()
        {
            InitializeComponent();
        }

        private void ServerController_FormClosing(object sender, FormClosingEventArgs e)
        {
            //判断是否是关闭窗体,如果是则关闭,如果不是,则最小化窗体.
            if (IsClosed)
            {

            }
            else
            {
                e.Cancel = true;
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsRunning)
            {
                MessageBox.Show("Please stop the server first!", QCP.Center.Properties.Settings.Default.AppName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (MessageBox.Show("Are you sure to exit?", QCP.Center.Properties.Settings.Default.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                IsClosed = true;
                this.Close();
            }
        }

        private void notifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //双击任务栏图标的时候恢复窗体.
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void ServerController_Load(object sender, EventArgs e)
        {
            //读取网络服务信息
            LoadNetConfig();
            //读取服务器信息
            LoadServerInfo();

            if (QCP.Center.Properties.Settings.Default.AutoStart)
            {
                StartServer();
            }
        }        

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //启动SuperWebSocket服务器
            StartServer();
        }

        /// <summary>
        /// 读取SuperSocket配置
        /// </summary>
        private void LoadNetConfig()
        {
            bootstrap = BootstrapFactory.CreateBootstrap();
            if (!bootstrap.Initialize())
            {
                this.notifyIconMain.ShowBalloonTip(100, QCP.Center.Properties.Settings.Default.AppName, "Failed to initialize network!", ToolTipIcon.Error);
            }
        }

        /// <summary>
        /// 读取服务器信息
        /// </summary>
        private void LoadServerInfo()
        {
            this.labelHostName.Text = QCP.Tool.NetTools.GetHostName();//机器名
            this.toolStripStatusLabelHostName.Text = QCP.Tool.NetTools.GetHostName();//机器名
            this.labelIPV4.Text = QCP.Tool.NetTools.GetFirstIPV4().ToString();//IPV4地址
            this.labelIPV6.Text = QCP.Tool.NetTools.GetFirstIPV6().ToString();//IPV6地址
            
            this.buttonStart.Enabled = true;
        }

        /// <summary>
        /// 启动服务器
        /// </summary>
        private void StartServer()
        {
            var result = bootstrap.Start();

            //如果启动成功,则设置按钮状态.如果失败,则提示信息.
            if (result == StartResult.Success)
            {
                IsRunning = true;
                //设置按钮状态
                this.buttonStart.Enabled = false;                
                this.buttonStop.Enabled = true;
                //设置任务栏菜单状态
                this.startToolStripMenuItem.Enabled = false;                
                this.stopToolStripMenuItem.Enabled = true;
                //提示信息
                this.labelServerStatus.Text = "Server Running.";                
            }
            else
            {
                this.notifyIconMain.ShowBalloonTip(100, QCP.Center.Properties.Settings.Default.AppName, "Server Start Failed.", ToolTipIcon.Error);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopServer();
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
                this.buttonStart.Enabled = true;
                this.buttonStop.Enabled = false;
                //设置任务栏菜单状态
                this.startToolStripMenuItem.Enabled = true;
                this.stopToolStripMenuItem.Enabled = false;
                //提示信息
                this.labelServerStatus.Text = "Server Stoped.";

            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonStart_Click(null, null);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonStop_Click(null, null);
        }
    }
}
