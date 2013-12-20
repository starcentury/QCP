using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using QCP.MQ;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEFTest
{
    [Export(typeof(IPlugin.IPlugin))]
    public class Test : IPlugin.IPlugin, IDisposable
    {
        private RabbitMQServices iRabbitMQServices;
        private RabbitMQServices iDataRabbitMQServices;
        private MongoDatabase mydb;

        public void Dispose()
        {
            if (iRabbitMQServices != null)
            {
                iRabbitMQServices.Dispose();
                iRabbitMQServices = null;
            }
        }

        public bool Start()
        {
            //iRabbitMQServices = new RabbitMQServices("QCP.Storage");
            //iRabbitMQServices.OnMessage += iRabbitMQServices_OnMessage;
            //iRabbitMQServices.StartGetMessage();
            //iDataRabbitMQServices = new RabbitMQServices("QCP.Data");
            return true;
        }

        void iRabbitMQServices_OnMessage(string message)
        {
            try
            {
                if (message != "")
                {
                    //StorageFileMessage RealMsg = (StorageFileMessage)msg.Body;
                    ////判断是否为存储消息
                    //if (RealMsg != null)
                    //{
                    //    //开始存储文件
                    //}

                    //以下为测试代码
                    //mongoDb服务实例连接字符串
                    string con = "mongodb://localhost:27017";
                    //得到一个于mongoDB服务器连接的实例
                    MongoServer server = MongoServer.Create(con);

                    //获得一个与具体数据库连接对象,数据库名为gywdb
                    mydb = server.GetDatabase("QCP");

                    string path = message;

                    //定义一个本地文件的路径字符串
                    string localFileName = path;
                    //定义mongoDB数据库中文件的名称
                    string mongoDBFileName = Guid.NewGuid().ToString();
                    //设置GridFS文件中对应的集合前缀名
                    MongoGridFSSettings fsSetting = new MongoGridFSSettings() { Root = "fs" };
                    //实例化一个GridFS
                    MongoGridFS gridfs = new MongoGridFS(mydb, fsSetting);
                    //将本地文件上传到mongoDB中去,以默认块的大小256KB对文件进行分块
                    MongoGridFSFileInfo info = gridfs.Upload(localFileName, mongoDBFileName);

                    //iDataRabbitMQServices.SendMessage("QCP.Data", info.Id.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
