using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VxTel.Core.Domains;
using VxTel.Shared.Dto;

namespace VxTel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComparePriceController : ControllerBase
    {
        private ComparePriceDomain _compareDomain;

        public ComparePriceController(ComparePriceDomain compareDomain)
        {  
            _compareDomain = compareDomain;
        }

        [HttpPost("PostCallCompare")]
        public async Task<IActionResult> ComparePricesAsync(InputCompareDto input)
        {
            try
            {
                return Ok(await _compareDomain.GetCompareUsagePrice(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}