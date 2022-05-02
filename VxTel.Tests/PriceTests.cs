using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VxTel.Api.Domains.Implementation;
using VxTel.Shared.DefaultValues;
using VxTel.Shared.Models;
using Xunit;

namespace VxTel.Tests
{
    public class PriceTests : DbTests
    {
        [Fact]
        public async Task MustAddNewCallOriginDestiny()
        {

            var context = await CreateTestDbAsync();

            var _priceDomain = new CallPriceDomain(context);

            int id = await _priceDomain.AddPrice(new CallPrice()
            {
                FromDDD = "99",
                ToDDD = "01",
                PricePerMinute = 2.45
            });

            var price = _priceDomain.GetPriceById(id);


            Assert.NotNull(price);


            await DeleteTestDbAsync(context);

        }

        public async Task MustFailRequestingNotFoundId()
        {
            var context = await CreateTestDbAsync();

            var _priceDomain = new CallPriceDomain(context);

            var defaultCreatedprices = await _priceDomain.GetAllPrices();

            Func<Task> act = async () => await _priceDomain.GetPriceById(defaultCreatedprices.Select(a => a.Id).Max() + 1);

            Exception exception = await Assert.ThrowsAsync<Exception>(act);

            Assert.Equal("Preço não encontrado", exception.Message);
        }

        [Fact]
        public async Task CheckSeedsWereCreated()
        {
            var context = await CreateTestDbAsync();
            var _priceDomain = new CallPriceDomain(context);
            var _defaultCallprices = new DefaultCallPrice();


            var defaultToCreatePrices = _defaultCallprices.GetDefaultPrices();

            var defaultCreatedPrices = await _priceDomain.GetAllPrices();

            Assert.Equal(defaultToCreatePrices.Count, defaultCreatedPrices.Count);

            await DeleteTestDbAsync(context);
        }

        [Theory]
        [MemberData(nameof(CallPrices))]
        public async Task MustFailOnDuplicatedFromToDDD(CallPrice callPrice)
        {
            var context = await CreateTestDbAsync();
            var _priceDomain = new CallPriceDomain(context);            

            await _priceDomain.AddPrice(callPrice);

            Func<Task> act = async () => await _priceDomain.AddPrice(callPrice);

            Exception exception = await Assert.ThrowsAsync<Exception>(act);

            Assert.Equal($"Já existe um registro com origem DDD {callPrice.FromDDD} e destino { callPrice.ToDDD}", exception.Message);

            await DeleteTestDbAsync(context);
        }



        public static IEnumerable<CallPrice[]> CallPrices => new List<CallPrice[]> {
            new CallPrice[] { new CallPrice() { PricePerMinute = 1.5, FromDDD = "100", ToDDD = "101"} },
        };

    }
}