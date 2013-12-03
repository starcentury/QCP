using System;
using System.Collections.Generic;
using System.Text;

namespace QCP.NetworkDataModel
{
    public class Server : ModelBase
    {
        public Server()
        {
            this.Category = CategoryType.Server;
            IsAuth = false;
        }
        
        public string Name { get; set; }
        public bool IsAuth { get; set; }
    }

    public class ServerCollection
    {
        private List<Server> _Servers;

        public List<Server> Servers
        {
            get
            {
                return _Servers;
            }
        }

        public void AddServer(Server server)
        {
            _Servers.Add(server);
        }

        public bool RemoveServer(string ID)
        {
            foreach (var item in _Servers)
            {
                if (item.ID == ID)
                {
                    _Servers.Remove(item);
                    return true;
                }
            }

            return false;
        }

        public Server GetServer(string ID)
        {
            foreach (var item in _Servers)
            {
                if (item.ID == ID)
                    return item;
            }

            return null;
        }
    }
}
