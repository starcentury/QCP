using System;
using System.AddIn;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Authorize
{
    [AddIn("AuthorizeServices", Description = "Authorize Services", Publisher = "QCP", Version = "1.0.0")]
    public class AuthorizeServices : QCP.Plugin.AddinSideView.AddinSideView
    {
        public bool Start()
        {
            return true;
        }
    }
}
