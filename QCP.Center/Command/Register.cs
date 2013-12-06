using Newtonsoft.Json;
using SuperWebSocket.SubProtocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Center.Command
{
    public class Register : SubCommandBase<QCPSession>
    {
        public override void ExecuteCommand(QCPSession session, SubRequestInfo requestInfo)
        {
            //转换对象
            QCP.NetworkDataModel.Server server = JsonConvert.DeserializeObject<QCP.NetworkDataModel.Server>(requestInfo.Body);

            object o = JsonConvert.DeserializeObject(requestInfo.Body);
            JsonTextReader reader = new JsonTextReader(new StringReader(requestInfo.Body));           

            while (reader.Read())
            {
                if (reader.TokenType.ToString() == "ID")
                {

                }
            }

            //判断是否注册过,没有则注册该服务器,最后返回注册成功的消息.
            if (server.ID == "")
            {
                server.ID = Guid.NewGuid().ToString();
                server.IsAuth = true;
                session.Send(server.ToJson());
            }
            else
            {

            }
        }
    }
}
