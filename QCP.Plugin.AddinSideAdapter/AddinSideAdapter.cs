using System;
using System.AddIn.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Plugin.AddinSideAdapter
{
    [AddInAdapter]
    public class AddinSideAdapter : ContractBase, QCP.Plugin.IContract.IContract
    {
        private QCP.Plugin.AddinSideView.AddinSideView _handler;

        public AddinSideAdapter(QCP.Plugin.AddinSideView.AddinSideView handler)
        {
            this._handler = handler;
        }

        public bool Start()
        {
            return this._handler.Start();
        }
    }
}
