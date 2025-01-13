using AutoMapper;
using HeribertoAPI.Models.Domain;
using HeribertoAPI.Models.DTO;

namespace HeribertoAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, AddRegionRequestDto>().ReverseMap();
        }
    }
}
