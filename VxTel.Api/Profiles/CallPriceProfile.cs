using AutoMapper;
using VxTel.Shared.Dto;
using VxTel.Shared.Models;

namespace FilmesApi.Profiles
{
    public class CallPriceProfile : Profile
    {
        public CallPriceProfile()
        {
            CreateMap<CallPriceDto, CallPrice>();
            CreateMap<CallPrice, CallPriceDto>();
        }
    }
}
