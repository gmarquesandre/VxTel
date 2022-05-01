using VxTel.Shared.Models;

namespace VxTel.Shared.DefaultValues
{
    public class DefaultCallPrice
    {
        public DefaultCallPrice()
        {

        }

        public List<CallPrice> GetDefaultPrices()
        {
            List<CallPrice> callPriceDefault = new()
            {
                new() { Id = 1, FromDDD = "011", ToDDD = "016", PricePerMinute = 1.90 },
                new() { Id = 2, FromDDD = "016", ToDDD = "011", PricePerMinute = 2.90 },
                new() { Id = 3, FromDDD = "011", ToDDD = "017", PricePerMinute = 1.70 },
                new() { Id = 4, FromDDD = "017", ToDDD = "011", PricePerMinute = 2.70 },
                new() { Id = 5, FromDDD = "011", ToDDD = "018", PricePerMinute = 0.90 },
                new() { Id = 6, FromDDD = "018", ToDDD = "011", PricePerMinute = 1.90 },
            };

            return callPriceDefault;
        }

    }
}
