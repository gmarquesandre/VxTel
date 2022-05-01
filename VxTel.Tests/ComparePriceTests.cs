using System;
using System.Linq;
using System.Threading.Tasks;
using VxTel.Api.Domains.Implementation;
using VxTel.Shared.DefaultValues;
using VxTel.Shared.Models;
using Xunit;

namespace VxTel.Tests
{
    public class ComparePriceTests : DbTests
    {
        [Fact]
        public async Task MustAddNewCallOriginDestiny()
        {
            var context = await CreateTestDbAsync();

            var _priceDomain = new CallPriceDomain(context);
            var _planDomain = new CallPriceDomain(context);




            int id = await _priceDomain.AddPrice(new CallPrice()
            {
                FromDDD = "99",
                ToDDD = "01",
                PricePerMinute = 2.45
            });

            var price = _priceDomain.GetPriceById(id);

            Assert.NotNull(price);

        }

        public async Task MustFailRequestingNotFoundId()
        {
            var context = await CreateTestDbAsync();

            var _priceDomain = new CallPriceDomain(context);

            var defaultCreatedprices = _priceDomain.GetAllPrices();

            Action act = async () => await _priceDomain.GetPriceById(defaultCreatedprices.Select(a => a.Id).Max() + 1);

            Exception exception = Assert.Throws<Exception>(act);

            Assert.Equal("priceo não encontrado", exception.Message);
        }

        [Fact]
        public async Task CheckSeedsWereCreated()
        {
            var context = await CreateTestDbAsync();
            var _priceDomain = new CallPriceDomain(context);
            var _defaultCallprices = new DefaultCallPrice();


            var defaultToCreatePrices = _defaultCallprices.GetDefaultPrices();

            var defaultCreatedPrices = _priceDomain.GetAllPrices();

            Assert.Equal(defaultToCreatePrices.Count, defaultCreatedPrices.Count);

            await DeleteTestDbAsync(context);
        }


    }
}