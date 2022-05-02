using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Core.Domains;
using VxTel.Shared.Dto;
using VxTel.Shared.Models;
using Xunit;

namespace VxTel.Tests
{
    public class ComparePriceTests : DbTests
    {
     
        [Theory]
        [MemberData(nameof(CompareParameters))]
        public async Task CheckOutputOnComparePlan(CallPrice priceTest, CallPlan planTest, InputCompareDto inputTest, OutputPriceCompareDto outputTest)
        {
            var context = await CreateTestDbAsync();

            var _priceDomain = new CallPriceDomain(context);
            var _planDomain = new CallPlanDomain(context);
            var _comparePriceDomain = new ComparePriceDomain(_planDomain, _priceDomain);

            await _priceDomain.AddPrice(priceTest);
            int idPlan = await _planDomain.AddPlanAsync(planTest);

            inputTest.CallPlanId = idPlan;

            var response = await _comparePriceDomain.GetCompareUsagePrice(inputTest);

            string jsonTest = JsonConvert.SerializeObject(outputTest);
            string jsonOutput = JsonConvert.SerializeObject(response);

            await DeleteTestDbAsync(context);
            Assert.True(jsonTest == jsonOutput);
        }


        private static readonly double PricePerMinuteTest30Minutes = 1.5;

        //DDD vai até 099 atualmente, utilizei numeros absurdos para não haver problema
        private static readonly string TestFromDDD = "999";
        private static readonly string TestToDDD = "998";
        private static readonly int TestFreeTime30Minutes = 30;
        private static readonly double TestPrice30Minutes = 40;
        private static readonly double ExceededValueTest30Minutes = 0.1;
        private static readonly string NameTest30Minutes = "Teste 30";
        private static readonly List<int> ListCallTimeValues = new() { 20, 29, 30, 50, 70 };
        private static CallPlan CallPlanTest30Minutes => new() { ExcedeedTimeFeePercentage = 0.1, Name = NameTest30Minutes, Price = TestPrice30Minutes, FreeTime = TestFreeTime30Minutes };
        private static CallPrice CallPriceTest30Minutes => new() { PricePerMinute = PricePerMinuteTest30Minutes, FromDDD = TestFromDDD, ToDDD = TestToDDD };


        public static IEnumerable<object[]> CompareParameters()
        {            
            yield return new object[]
            {
                CallPriceTest30Minutes,
                CallPlanTest30Minutes,
                new InputCompareDto() { CallTime = ListCallTimeValues[0], FromDDD = TestFromDDD, ToDDD = TestToDDD },
                new OutputPriceCompareDto() { CallPlanName = NameTest30Minutes, PriceWithPlan = TestPrice30Minutes, PriceWithoutPlan = ListCallTimeValues[0] * PricePerMinuteTest30Minutes, CallTime = ListCallTimeValues[0], FromDDD = TestFromDDD, ToDDD = TestToDDD }
            };

            yield return new object[]
            {
                CallPriceTest30Minutes,
                CallPlanTest30Minutes,
                new InputCompareDto() { CallTime = ListCallTimeValues[1], FromDDD = TestFromDDD, ToDDD = TestToDDD },
                new OutputPriceCompareDto() { CallPlanName = NameTest30Minutes, PriceWithPlan = TestPrice30Minutes, PriceWithoutPlan = ListCallTimeValues[1] * PricePerMinuteTest30Minutes, CallTime = ListCallTimeValues[1], FromDDD = TestFromDDD, ToDDD = TestToDDD }
            };
            yield return new object[]
            {
                CallPriceTest30Minutes,
                CallPlanTest30Minutes,
                new InputCompareDto() { CallTime = ListCallTimeValues[2], FromDDD = TestFromDDD, ToDDD = TestToDDD },
                new OutputPriceCompareDto() { CallPlanName = NameTest30Minutes, PriceWithPlan = TestPrice30Minutes, PriceWithoutPlan = ListCallTimeValues[2] * PricePerMinuteTest30Minutes, CallTime = ListCallTimeValues[2], FromDDD = TestFromDDD, ToDDD = TestToDDD }
            };
            yield return new object[]
            {
                CallPriceTest30Minutes,
                CallPlanTest30Minutes,
                new InputCompareDto() { CallTime = ListCallTimeValues[3], FromDDD = TestFromDDD, ToDDD = TestToDDD },
                new OutputPriceCompareDto() { CallPlanName = NameTest30Minutes, PriceWithPlan = TestPrice30Minutes + ( ListCallTimeValues[3] - TestFreeTime30Minutes) * PricePerMinuteTest30Minutes * (1 + ExceededValueTest30Minutes), PriceWithoutPlan = ListCallTimeValues[3] * PricePerMinuteTest30Minutes, CallTime = ListCallTimeValues[3], FromDDD = TestFromDDD, ToDDD = TestToDDD }
            };
            yield return new object[]
            {
                CallPriceTest30Minutes,
                CallPlanTest30Minutes,
                new InputCompareDto() { CallTime = ListCallTimeValues[4], FromDDD = TestFromDDD, ToDDD = TestToDDD },
                new OutputPriceCompareDto() { CallPlanName = NameTest30Minutes, PriceWithPlan = TestPrice30Minutes + ( ListCallTimeValues[4] - TestFreeTime30Minutes) * PricePerMinuteTest30Minutes * (1 + ExceededValueTest30Minutes), PriceWithoutPlan = ListCallTimeValues[4] * PricePerMinuteTest30Minutes, CallTime = ListCallTimeValues[4], FromDDD = TestFromDDD, ToDDD = TestToDDD }
            };
        }

    }
}