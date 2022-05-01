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
        public IActionResult GetlCallPlans()
        {
            var plans = _planDomain.GetAllPlans();
            //Mapear para Dto
            return Ok(plans);
        }

    }
}