using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.AddIn;
using System.AddIn.Pipeline;

namespace MAF
{
    [AddIn("Addin_2", Description = "this is Addin_2", Publisher = "Addin_2", Version = "1.0")]
    public class Addin_2 : AddinSideView
    {
        public string Say()
        {
            return "Addin_2";
        }
    }
}
