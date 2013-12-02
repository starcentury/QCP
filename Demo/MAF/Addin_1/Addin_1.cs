using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.AddIn;
using System.AddIn.Pipeline;

namespace MAF
{
    [AddIn("Addin_1", Description = "this is Addin_1", Publisher = "Addin_1", Version = "1.0")]
    public class Addin_1 : AddinSideView
    {
        public string Say()
        {
            return "Addin_1";
        }
    }
}
