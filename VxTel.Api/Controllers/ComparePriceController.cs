using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Domains.Implementation;
using VxTel.Shared.Dto;

namespace VxTel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComparePriceController : ControllerBase
    {
        private IMapper _mapper;
        private ComparePriceDomain _compareDomain;

        public ComparePriceController(IMapper mapper, ComparePriceDomain compareDomain)
        {
            _mapper = mapper;   
            _compareDomain = compareDomain;
        }

        [HttpPost("PostCallCompare")]
        public async Task<IActionResult> ComparePricesAsync(InputCompareDto input)
        {          
            return Ok(await _compareDomain.GetCompareUsagePrice(input));

        }

    }
}