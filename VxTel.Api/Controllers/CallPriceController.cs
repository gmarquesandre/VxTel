using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VxTel.Core.Domains;
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
        public async Task<IActionResult> GetCallPrices()
        {
            var prices = await _priceDomain.GetAllPrices();
            //Mapear para Dto
            return Ok(_mapper.Map<List<CallPriceDto>>(prices));
        }

    }
}