using VxTel.Api.Domains.Interface;
using VxTel.Shared.Models;

namespace VxTel.Api.Domains.Implementation
{
    public class CallPriceDomain : ICallPriceDomain
    {
        public VxTelDbContext _context;
        public CallPriceDomain()
        {
            _context = new VxTelDbContext();
        }

        public List<CallPrice> GetAllPrices()
        {
            return _context.CallPrices.ToList();
        }

        public CallPrice GetPriceByOriginAndDestiny(string fromDDD, string toDDD)
        {
            var callPrice = _context.CallPrices.FirstOrDefault(a => a.FromDDD == fromDDD && a.ToDDD == toDDD);

            if (callPrice == null)
            {
                throw new Exception($"Ligação com DDD Origem {fromDDD} e DDD Destino {toDDD} não é atendida pela VxTel");
            }

            return callPrice;
        }




    }
}