using Newtonsoft.Json;
using SuperWebSocket.SubProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Server.Command
{
    public class Auth : SubCommandBase<LocalServerSession>
    {
        public override void ExecuteCommand(LocalServerSession session, SubRequestInfo requestInfo)
        {
            SystemPerformance.NetworkReciveByte += requestInfo.Body.Length;

            QCP.NetworkDataModel.Client client = JsonConvert.DeserializeObject<QCP.NetworkDataModel.Client>(requestInfo.Body);            
        }
    }
}
