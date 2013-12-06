using System;
using System.AddIn;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Security
{
    [AddIn("SecurityServices",Description="Security Services",Publisher= "QCP",Version="1.0.0")]
    public class SecurityServices : QCP.Plugin.AddinSideView.AddinSideView
    {
        public bool Start()
        {
            return true;
        }
    }
}
