using VxTel.Shared.Dto;
using VxTel.Shared.Models;

namespace VxTel.Api.Domains.Implementation
{
    public interface IComparePriceDomain
    {
        Task<CallPriceCompareDto> GetCompareUsagePrice(InputCompareDto input);
        double GetPriceWithPlan(CallPlan planType, CallPrice callPrice, int callTime);
    }
}