using VxTel.Api.Domains.Interface;
using VxTel.Shared.Models;

namespace VxTel.Api.Domains.Implementation
{
    public class CallPlanDomain : ICallPlanDomain
    {
        private VxTelDbContext _context;
        public CallPlanDomain()
        {
            _context = new VxTelDbContext();
        }

        public List<CallPlan> GetAllPlans()
        {
            return _context.CallPlans.ToList();
        }

        public CallPlan GetPlanById(int id)
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