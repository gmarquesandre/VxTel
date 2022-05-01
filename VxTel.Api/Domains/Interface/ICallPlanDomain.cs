using VxTel.Shared.Models;

namespace VxTel.Api.Domains.Implementation
{
    public interface ICallPlanDomain
    {
        Task<int> AddPlanAsync(CallPlan callPlan);
        Task<List<CallPlan>> GetAllPlans();
        Task<CallPlan> GetPlanById(int id);
    }
}