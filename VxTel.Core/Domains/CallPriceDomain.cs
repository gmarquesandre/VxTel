using Microsoft.EntityFrameworkCore;
using VxTel.EntityFramework;
using VxTel.Shared.Models;

namespace VxTel.Core.Domains
{
    public class CallPriceDomain
    {
        public VxTelDbContext _context;
        public CallPriceDomain(VxTelDbContext context)
        {
            _context = context;
        }

        public async Task<List<CallPrice>> GetAllPrices()
        {
            return await _context.CallPrices.ToListAsync();
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

        public async Task<CallPrice> GetPriceById(int id)
        {
            var callPrice = await _context.CallPrices.FirstOrDefaultAsync(a => a.Id == id);

            if (callPrice == null)
            {
                throw new Exception("Preço não encontrado");
            }

            return callPrice;

        }

        public async Task<int> AddPrice(CallPrice callPrice)
        {
            CheckIfPriceIsValid(callPrice);

            await CheckIfAlreadyExists(callPrice);

            await _context.CallPrices.AddAsync(callPrice);

            await _context.SaveChangesAsync();

            return callPrice.Id;

        }

        private async Task CheckIfAlreadyExists(CallPrice callPrice)
        {
            var price = await _context.CallPrices.FirstOrDefaultAsync(a => a.FromDDD == callPrice.FromDDD && a.ToDDD == callPrice.ToDDD);

            if (price != null)
                throw new Exception($"Já existe um registro com origem DDD {callPrice.FromDDD} e destino {callPrice.ToDDD}");
        }

        private void CheckIfPriceIsValid(CallPrice callPrice)
        {
            if (callPrice.ToDDD == callPrice.FromDDD)
                throw new Exception("o DDD de origem deve ser diferente do de destino");
        }
    }
}