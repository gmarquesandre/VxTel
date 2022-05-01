using VxTel.Shared.Models;

namespace VxTel.Api.Domains.Interface
{
    public interface ICallPriceDomain
    {
        List<CallPrice> GetAllPrices();
        CallPrice GetPriceByOriginAndDestiny(string fromDDD, string toDDD);
    }
}