using SuperSocket.SocketBase;
using SuperWebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Center
{
    public class QCPSession : WebSocketSession<QCPSession>
    {
        protected override void OnSessionStarted()
        {
            base.OnSessionStarted();            
        }
    }
}
