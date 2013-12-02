using System.AddIn.Pipeline;

namespace MAF
{
    [HostAdapter()]
    public class HostSideAdapter : HostSideView
    {
        private IContract _contract;
        private System.AddIn.Pipeline.ContractHandle _handle;
        public HostSideAdapter(IContract contract)
        {
            this._contract = contract;
            this._handle = new ContractHandle(contract);
        }
        public string Say()
        {
            return this._contract.Say();
        }
    }
}
