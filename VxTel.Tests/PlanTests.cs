using System;
using System.Linq;
using System.Threading.Tasks;
using VxTel.Core.Domains;
using VxTel.EntityFramework.DefaultValues;
using VxTel.Shared.Models;
using Xunit;

namespace VxTel.Tests
{
    public class PlanTests : DbTests
    {
        [Fact]
        public async Task MustAddNewPlan()
        {
            var context = await CreateTestDbAsync();           

            var _planDomain = new CallPlanDomain(context);            

            int id = await _planDomain.AddPlanAsync(new CallPlan()
            {
                ExcedeedTimeFeePercentage= 0.2,
                FreeTime = 30,
                Name = "Plan Test",
                Price = 30
            });

            var plan = _planDomain.GetPlanById(id);

            Assert.NotNull(plan);

        }
        [Theory]
        [InlineData(null, 30.00, 30, 0.1, "O plano deve ter um nome" )]
        [InlineData("Teste 2", 0.00, 0, 0.1, "O preço do plano deve ser maior que zero")]
        [InlineData("Teste 3", 30.00, 0, 0.1, "O tempo gratuíto do plano deve ser maior que zero")]
        public async Task MustFailAddNewPlan(string name,double price, int freeTime, double exceededFeePercentage, string errorMessage)
        {
            var context = await CreateTestDbAsync();
            var _planDomain = new CallPlanDomain(context);
            var newPlan = new CallPlan()
            {
                ExcedeedTimeFeePercentage = exceededFeePercentage,
                FreeTime = freeTime,
                Name = name,
                Price = price
            };

            Func<Task> act = (async () => await _planDomain.AddPlanAsync(newPlan));
            Exception exception = await Assert.ThrowsAsync<Exception>(act);

            Assert.Equal(errorMessage, exception.Message);

            await DeleteTestDbAsync(context);
        }

        [Fact]
        public async Task MustFailRequestingNotFoundId()
        {
            var context = await CreateTestDbAsync();

            var _planDomain = new CallPlanDomain(context);

            var defaultCreatedPlans = await _planDomain.GetAllPlans();

            Func<Task> act = async () => await _planDomain.GetPlanById(defaultCreatedPlans.Select(a => a.Id).Max() + 1);

            Exception exception = await Assert.ThrowsAsync<Exception>(act);

            Assert.Equal("Plano não encontrado", exception.Message);
        }

        [Fact]
        public async Task CheckSeedsWereCreated()
        {
            var context = await CreateTestDbAsync();
            var _planDomain = new CallPlanDomain(context);
            var _defaultCallPlans = new DefaultCallPlan();


            var defaultToCreatePlans = _defaultCallPlans.GetDefaultPlans();

            var defaultCreatedPlans = await _planDomain.GetAllPlans();

            Assert.Equal(defaultToCreatePlans.Count, defaultCreatedPlans.Count);

            await DeleteTestDbAsync(context);
        }

       
    }
}