using VxTel.Shared.Models;

namespace VxTel.Shared.DefaultValues
{
    public class DefaultCallPlan
    {
        public DefaultCallPlan()
        {

        }

        public List<CallPlan> GetDefaultPlans()
        {
            List<CallPlan> callPlanDefault = new()
            {
                new() { Id = 1, FreeTime = 30, Name = "FaleMais 30", ExcedeedTimeFeePercentage = 0.1, Price = 10 },
                new() { Id = 2, FreeTime = 60, Name = "FaleMais 60", ExcedeedTimeFeePercentage = 0.1, Price = 20 },
                new() { Id = 3, FreeTime = 120, Name = "FaleMais 120", ExcedeedTimeFeePercentage = 0.1, Price = 30 }
            };

            return callPlanDefault;
        }

    }
}
