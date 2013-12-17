using System;
using System.AddIn.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCP.Plugin.HostSideAdapter
{
    [HostAdapter()]
    public class HostSideAdapter : QCP.Plugin.HostSideView.HostSideView, IDisposable
    {
        private QCP.Plugin.IContract.IContract _contract;
        private System.AddIn.Pipeline.ContractHandle _handle;
        
        public HostSideAdapter(QCP.Plugin.IContract.IContract contract)
        {
            this._contract = contract;
            this._handle = new ContractHandle(contract);
        }        

        public bool Start()
        {
            try
            {
                return this._contract.Start();
            }
            catch
            {                
                throw;
            }            
        }

        public void Dispose()
        {
            if (_handle != null)
            {
                _handle.Dispose();
                _handle = null;
            }
        }
    }
}
