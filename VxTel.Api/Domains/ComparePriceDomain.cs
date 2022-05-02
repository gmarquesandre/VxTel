using VxTel.Shared.Dto;
using VxTel.Shared.Models;

namespace VxTel.Api.Domains.Implementation
{
    public class ComparePriceDomain
    {
        private readonly CallPlanDomain _planDomain;
        private readonly CallPriceDomain _priceDomain;
        public ComparePriceDomain(CallPlanDomain planDomain, CallPriceDomain priceDomain)
        {
            _planDomain = planDomain;
            _priceDomain = priceDomain;
        }

        public async Task<OutputPriceCompareDto> GetCompareUsagePrice(InputCompareDto input)
        {
            var callPrice = _priceDomain.GetPriceByOriginAndDestiny(input.FromDDD, input.ToDDD);

            var planType = await _planDomain.GetPlanById(input.CallPlanId);

            var priceWithPlan = GetPriceWithPlan(planType, callPrice, input.CallTime);

            var result = new OutputPriceCompareDto
            {
                PriceWithoutPlan = callPrice.PricePerMinute * input.CallTime,
                PriceWithPlan = priceWithPlan,
                CallTime = input.CallTime,
                CallPlanName = planType.Name,
                FromDDD = input.FromDDD,
                ToDDD = input.ToDDD
            };

            return result;



        }
        public double GetPriceWithPlan(CallPlan planType, CallPrice callPrice, int callTime)
        {
            if (callTime <= planType.FreeTime)
                return planType.Price;

            double timePrice = (callTime - planType.FreeTime) * callPrice.PricePerMinute * ( 1 + planType.ExcedeedTimeFeePercentage);

            double totalPrice = timePrice + planType.Price;

            return totalPrice;
        }
    }
}