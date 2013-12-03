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
        /// <summary>
        /// 唯一标示
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 网络连接的ID
        /// </summary>
        public string SessionID { get; set; } 
    
        /// <summary>
        /// 所属类别,用于标示模型所属的类别
        /// </summary>
        public CategoryType Category { get; set; }
        
        /// <summary>
        /// 所属类别的枚举
        /// </summary>
        public enum CategoryType
        {
            Client = 0,
            Server = 1,
        }

        /// <summary>
        /// 将对象转换成Json方法
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            try
            {
                return JsonConvert.SerializeObject(this);
            }
            catch
            {
                return null;
            }
            
        }

        /// <summary>
        /// 将对象转换成byte[]的方法
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ms, this);
                    return ms.GetBuffer();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
