using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Tool
{
    public static class FileTools
    {
        /// <summary>
        /// 获取文件分包的总数量
        /// </summary>
        /// <param name="fileLength">文件大小</param>
        /// <param name="packageSize">分包大小</param>
        /// <returns></returns>
        public static int GetFilePackageCount(long fileLength, int packageSize)
        {
            if (fileLength % packageSize > 0)
            {
                return Convert.ToInt32(fileLength / packageSize) + 1;
            }
            else
            {
                return Convert.ToInt32(fileLength / packageSize);
            } 
        }

        /// <summary>
        /// 按分包读取文件,返回byte[]
        /// </summary>
        /// <param name="filePath">源文件路径</param>
        /// <param name="index">分包序号</param>
        /// <param name="packageSize">分包大小</param>
        /// <returns></returns>
        public static byte[] ReadFile(string filePath, int index, int packageSize)
        {            
            try
            {
                byte[] resutl = null;
                long length = (long)index * (long)packageSize + packageSize;
                using (System.IO.FileStream stream = System.IO.File.OpenRead(filePath))
                {
                    if (length > stream.Length)
                    {
                        resutl = new byte[stream.Length - ((long)index * (long)packageSize)];
                    }
                    else
                    {
                        resutl = new byte[packageSize];
                    }
                    stream.Seek((long)index * (long)packageSize, System.IO.SeekOrigin.Begin);
                    stream.Read(resutl, 0, resutl.Length);
                }
                return resutl;
            }
            catch
            {
                return null;
            }
        }
    }
}
