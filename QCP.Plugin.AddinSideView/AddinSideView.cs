using System;
using System.AddIn.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Plugin.AddinSideView
{
    [AddInBase()]
    public interface AddinSideView
    {
        bool Start();
    }
}
