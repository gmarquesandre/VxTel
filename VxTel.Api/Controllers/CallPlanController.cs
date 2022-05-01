using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Domains.Implementation;
using VxTel.Shared.Dto;

namespace VxTel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CallPlanController : ControllerBase
    {
        private IMapper _mapper;
        private CallPlanDomain _planDomain;

        public CallPlanController(IMapper mapper, CallPlanDomain planDomain)
        {
            _mapper = mapper;   
            _planDomain = planDomain;
        }

        [HttpGet("GetCallPlans")]
        public async Task<IActionResult> GetlCallPlansAsync()
        {
            var plans = await _planDomain.GetAllPlans();

            var plansDto = plans.Select(a => new CallPlanDto
            {
                ExcedeedTimeFeePercentage = a.ExcedeedTimeFeePercentage,
                FreeTime = a.FreeTime,
                Name = a.Name
            }).ToList();

            return Ok(plansDto);
        }

    }
}