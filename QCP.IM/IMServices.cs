using System;
using System.AddIn;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.IM
{
    [AddIn("IMServices", Description = "IM Services", Publisher = "QCP", Version = "1.0.0")]
    public class IMServices : QCP.Plugin.AddinSideView.AddinSideView
    {
        public bool Start()
        {
            return true;
        }
    }
}
