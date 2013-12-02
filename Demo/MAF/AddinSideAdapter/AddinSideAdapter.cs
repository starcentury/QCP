using System.AddIn.Pipeline;

namespace MAF
{
    [AddInAdapter]
    public class AddinSideAdapter : ContractBase, IContract
    {
        private AddinSideView _handler;

        public AddinSideAdapter(AddinSideView handler)
        {
            this._handler = handler;
        }

        public string Say()
        {

            return this._handler.Say();
        }
    }
}
