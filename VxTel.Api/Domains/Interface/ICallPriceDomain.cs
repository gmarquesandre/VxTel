using VxTel.Shared.Models;

namespace VxTel.Api.Domains.Implementation
{
    public interface ICallPriceDomain
    {
        Task<int> AddPrice(CallPrice callPrice);
        Task<List<CallPrice>> GetAllPrices();
        Task<CallPrice> GetPriceById(int id);
        CallPrice GetPriceByOriginAndDestiny(string fromDDD, string toDDD);
    }
}