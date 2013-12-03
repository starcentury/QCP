using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Tool
{
    public static class ConfigFileManager
    {
        //配置文件存储路径
        //static string ProfilePath;
        static string BinPath;

        static ConfigFileManager()
        {
            //ProfilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EdmxGenCsla");
            BinPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        #region 存取配置文件

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <typeparam name="T">配置类型</typeparam>
        /// <returns></returns>
        public static T LoadConfig<T>() where T : class, new()
        {
            Type t = typeof(T);
            string path = System.IO.Path.Combine(BinPath, t.Name + ".xml");
            if (!System.IO.File.Exists(path)) return null;
            else
            {
                T obj = null;

                using (System.IO.StreamReader sr = new System.IO.StreamReader(path, System.Text.Encoding.Unicode))
                {
                    System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(t);
                    obj = xml.Deserialize(sr) as T;
                    sr.Close();
                }
                return obj;
            }
        }

        public static T LoadConfig<T>(string path, string configName) where T : class, new()
        {
            Type t = typeof(T);
            if (string.IsNullOrEmpty(path))
                path = System.IO.Path.Combine(BinPath, configName + ".xml");
            else
                path = System.IO.Path.Combine(path, configName + ".xml");
            //string path = System.IO.Path.Combine(ProfilePath, t.Name + ".xml");
            if (!System.IO.File.Exists(path)) return null;
            else
            {
                T obj = null;

                using (System.IO.StreamReader sr = new System.IO.StreamReader(path, System.Text.Encoding.Unicode))
                {
                    System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(t);
                    obj = xml.Deserialize(sr) as T;
                    sr.Close();
                }
                return obj;
            }
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <typeparam name="T">配置类型</typeparam>
        /// <returns></returns>
        public static object LoadConfig(Type t, string configName)
        {
            string path = System.IO.Path.Combine(BinPath, configName + ".xml");
            if (!System.IO.File.Exists(path)) return null;
            else
            {
                object obj = null;

                using (System.IO.StreamReader sr = new System.IO.StreamReader(path, System.Text.Encoding.Unicode))
                {
                    System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(t);
                    obj = xml.Deserialize(sr);
                    sr.Close();
                }
                return obj;
            }
        }

        public static object LoadConfig(Type t, string path, string configName)
        {
            if (string.IsNullOrEmpty(path))
                path = System.IO.Path.Combine(BinPath, configName + ".xml");
            else
                path = System.IO.Path.Combine(path, configName + ".xml");
            if (!System.IO.File.Exists(path)) return null;
            else
            {
                object obj = null;

                using (System.IO.StreamReader sr = new System.IO.StreamReader(path, System.Text.Encoding.Unicode))
                {
                    System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(t);
                    obj = xml.Deserialize(sr);
                    sr.Close();
                }
                return obj;
            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="cfg">要保存的配置对象</param>
        public static void SaveConfig(object cfg)
        {
            if (cfg == null) throw new ArgumentNullException();

            Type t = cfg.GetType();
            string path = System.IO.Path.Combine(BinPath, t.Name + ".xml");
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));

            using (System.IO.StreamWriter sr = new System.IO.StreamWriter(path, false, System.Text.Encoding.Unicode))
            {
                System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(t);
                xml.Serialize(sr, cfg);
                sr.Close();
            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="cfg">要保存的配置对象</param>
        public static void SaveConfig(string configName, object cfg)
        {
            if (cfg == null) throw new ArgumentNullException();

            Type t = cfg.GetType();
            string path = System.IO.Path.Combine(BinPath, configName + ".xml");
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));

            using (System.IO.StreamWriter sr = new System.IO.StreamWriter(path, false, System.Text.Encoding.Unicode))
            {
                System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(t);
                xml.Serialize(sr, cfg);
                sr.Close();
            }
        }

        public static void SaveConfig(string path, string configName, object cfg)
        {
            if (cfg == null) throw new ArgumentNullException();

            Type t = cfg.GetType();

            if (string.IsNullOrEmpty(path))
                path = System.IO.Path.Combine(BinPath, configName + ".xml");
            else
                path = System.IO.Path.Combine(path, configName + ".xml");

            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));

            using (System.IO.StreamWriter sr = new System.IO.StreamWriter(path, false, System.Text.Encoding.Unicode))
            {
                System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(t);
                xml.Serialize(sr, cfg);
                sr.Close();
            }
        }

        #endregion
    }
}
