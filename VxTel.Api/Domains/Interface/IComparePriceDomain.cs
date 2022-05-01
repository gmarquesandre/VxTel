using VxTel.Shared.Dto;
using VxTel.Shared.Models;

namespace VxTel.Api.Domains.Interface
{
    public interface IComparePriceDomain
    {
        CallPriceCompareDto GetCompareUsagePrice(InputCompareDto input);
        double GetPriceWithPlan(CallPlan planType, CallPrice callPrice, int callTime);
    }
}