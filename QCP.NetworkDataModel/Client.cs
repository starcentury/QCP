using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QCP.NetworkDataModel
{
    [Serializable]
    public class Client : ModelBase
    {
        public string Name { get; set; }
        public bool IsAuth { get; set; }       
    }
}
