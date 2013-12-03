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

namespace WindowsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //WebSocket客户端
        private WebSocket iWebSocketClient;

        private void button1_Click(object sender, EventArgs e)
        {
            iWebSocketClient = new WebSocket("ws://127.0.0.1:2020/");
            iWebSocketClient.Opened += iWebSocketClient_Opened;
            iWebSocketClient.MessageReceived += iWebSocketClient_MessageReceived;

            iWebSocketClient.Open();
        }

        void iWebSocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            this.listBox1.Invoke(new Action(delegate()
            {
                this.listBox1.Items.Add(e.Message);
            }));
        }

        void iWebSocketClient_Opened(object sender, EventArgs e)
        {
            this.button1.Invoke(new Action(delegate()
            {
                this.button1.Text = "Linked";
                this.button1.Enabled = false;
                this.button2.Enabled = true;
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iWebSocketClient.Close();

            this.button1.Text = "Link";
            this.button1.Enabled = true;
            this.button2.Enabled = false;
        }
    }
}
