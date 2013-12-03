using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QCP.NetworkDataModel
{
    [Serializable]
    public class Client : ModelBase
    {
        public Client()
        {
            this.Category = CategoryType.Client;
        }

        public string Name { get; set; }
        public bool IsAuth { get; set; }       
    }

    [Serializable]
    public class ClientCollection
    {
        private List<Client> _Clients;

        public List<Client> Clients 
        {
            get
            {
                return _Clients;
            }
        }

        public void AddClient(Client client)
        {
            _Clients.Add(client);
        }

        public bool RemoveClient(string ID)
        {
            foreach (var item in _Clients)
            {
                if (item.ID == ID)
                {
                    _Clients.Remove(item);
                    return true;
                }
            }

            return false;
        }

        public Client GetClient(string ID)
        {
            foreach (var item in _Clients)
            {
                if (item.ID == ID)
                    return item;
            }

            return null;
        }
    }
}
