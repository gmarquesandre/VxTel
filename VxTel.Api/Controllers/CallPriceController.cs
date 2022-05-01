using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Domains.Implementation;
using VxTel.Shared.Dto;

namespace VxTel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CallPriceController : ControllerBase
    {
        private IMapper _mapper;
        private CallPriceDomain _priceDomain;

        public CallPriceController(IMapper mapper, CallPriceDomain priceDomain)
        {
            _mapper = mapper;   
            _priceDomain = priceDomain;
        }

        [HttpGet("GetCallPrices")]
        public async Task<IActionResult> GetlCallPrices()
        {
            var prices = await _priceDomain.GetAllPrices();
            //Mapear para Dto
            return Ok(prices);
        }

    }
}