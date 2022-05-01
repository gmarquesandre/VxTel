
using Microsoft.EntityFrameworkCore;
using VxTel.Shared.Models;

namespace VxTel.Api.Domains.Implementation
{
    public class CallPlanDomain : ICallPlanDomain
    {
        VxTelDbContext _context;
        public CallPlanDomain(VxTelDbContext context)
        {
            _context = context;
        }

        public async Task<List<CallPlan>> GetAllPlans()
        {
            return await _context.CallPlans.ToListAsync();
        }

        public async Task<int> AddPlanAsync(CallPlan callPlan)
        {
            CheckIfCallPlanIsValid(callPlan);

            await _context.CallPlans.AddAsync(callPlan);

            await _context.SaveChangesAsync();

            return callPlan.Id;
        }

        private void CheckIfCallPlanIsValid(CallPlan callPlan)
        {
            if (callPlan.Name == null)
                throw new Exception("O plano deve ter um nome");

            if (callPlan.Price <= 0.00)
                throw new Exception("O preço do plano deve ser maior que zero");

            if (callPlan.FreeTime <= 0)
                throw new Exception("O tempo gratuíto do plano deve ser maior que zero");


        }

        public async Task<CallPlan> GetPlanById(int id)
        {
            var plan = _context.CallPlans.FirstOrDefault(a => a.Id == id);
            if (plan == null)
            {
                throw new Exception("Plano não encontrado");
            }
            return plan;
        }
    }
}