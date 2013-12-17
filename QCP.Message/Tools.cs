using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Message
{
    public static class Tools
    {
        public static bool IsType(Type type, object obj)
       {
           if (obj != null)
            {
                if (obj.GetType() == type)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
