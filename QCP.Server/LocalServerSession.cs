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
            this.Send("Hello from local server.");
            base.OnSessionStarted();
        }

        public override void Send(string message)
        {
            SystemPerformance.NetworkSendByte += message.Length;
            base.Send(message);
        }

        public override void Send(string message, params object[] paramValues)
        {
            SystemPerformance.NetworkSendByte += paramValues.Length;
            base.Send(message, paramValues);
        }

        public override void Send(ArraySegment<byte> segment)
        {
            SystemPerformance.NetworkSendByte += segment.Count;
            base.Send(segment);
        }

        public override void Send(byte[] data, int offset, int length)
        {
            SystemPerformance.NetworkSendByte += length;
            base.Send(data, offset, length);
        }
    }
}
