using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace QCP.NetworkDataModel
{
    [Serializable]
    public class ModelBase
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public byte[] ToBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                return ms.GetBuffer();
            }
        }
    }
}
