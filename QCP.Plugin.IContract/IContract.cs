using System;
using System.AddIn.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Plugin.IContract
{
    [AddInContract]
    public interface IContract : System.AddIn.Contract.IContract
    {
        bool Start();
    }
}
