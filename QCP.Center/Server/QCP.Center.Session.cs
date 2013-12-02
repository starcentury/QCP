using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Center.Server
{
    public class QCPSession : AppSession<QCPSession>
    {
        protected override void OnSessionStarted()
        {
            base.OnSessionStarted();
        }
    }
}
