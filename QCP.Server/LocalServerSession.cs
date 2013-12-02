using SuperSocket.SocketBase;
using SuperWebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Server
{
    public class LocalServerSession : WebSocketSession<LocalServerSession>
    {
        protected override void OnSessionStarted()
        {
            base.OnSessionStarted();
        }
    }
}
