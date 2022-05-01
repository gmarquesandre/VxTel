using VxTel.Shared.Models;

namespace VxTel.Api.Domains.Interface
{
    public interface ICallPlanDomain
    {
        List<CallPlan> GetAllPlans();
        CallPlan GetPlanById(int id);
    }
}