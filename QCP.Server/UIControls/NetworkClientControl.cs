using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QCP.Server.UIControls
{
    public partial class NetworkClientControl : UserControl
    {
        private SuperWebSocket.IWebSocketServer iServer;
        
        public NetworkClientControl(SuperWebSocket.IWebSocketServer server)
        {
            InitializeComponent();
            iServer = server;
        }

        private void GetClientList()
        {
            
        }
    }
}
