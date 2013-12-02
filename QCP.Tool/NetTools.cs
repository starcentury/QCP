using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Tool
{
    public static class NetTools
    {
        public static string GetHostName()
        {
            return System.Net.Dns.GetHostName();
        }

        public static IPAddress[] GetLocalIP()
        {
            string name = Dns.GetHostName();
            IPHostEntry me = Dns.GetHostEntry(name);
            return me.AddressList;
        }

        public static IPAddress GetFirstIPV4()
        {
            IPAddress[] ips = GetLocalIP();
            foreach (IPAddress ip in ips)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                    continue;
                return ip;
            }

            return null;
        }

        public static IPAddress GetFirstIPV6()
        {
            IPAddress[] ips = GetLocalIP();
            foreach (IPAddress ip in ips)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    continue;
                return ip;
            }

            return null;
        }
    }
}
