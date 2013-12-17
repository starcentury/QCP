using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.MQ
{
    public static class ReservedMQNames
    {
        private static string[] ReservedName = new string[] 
        { 
            "Reserved",
        };

        public static bool IsReserved(string name)
        {
            if (ReservedName.Where(l => l == name).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
    }
}
