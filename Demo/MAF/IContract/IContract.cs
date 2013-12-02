using System.AddIn.Pipeline;

namespace MAF
{
    [AddInContract]
    public interface IContract : System.AddIn.Contract.IContract
    {
        string Say();
    }
}
