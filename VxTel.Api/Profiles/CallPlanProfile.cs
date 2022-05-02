using AutoMapper;
using VxTel.Shared.Dto;
using VxTel.Shared.Models;

namespace FilmesApi.Profiles
{
    public class CallPlanProfile : Profile
    {
        public CallPlanProfile()
        {
            CreateMap<CallPlanDto, CallPlan>();
            CreateMap<CallPlan, CallPlanDto>();
        }
    }
}
