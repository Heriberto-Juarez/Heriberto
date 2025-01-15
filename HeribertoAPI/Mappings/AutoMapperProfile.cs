using AutoMapper;
using HeribertoAPI.Models.Domain;
using HeribertoAPI.Models.DTO;

namespace HeribertoAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            /**
             * Region
             * 
             * */
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, AddRegionRequestDto>().ReverseMap();
            CreateMap<Region, UpdateRegionRequestDto>().ReverseMap();

            /**
             * Walk
             * */

            CreateMap<Walk, AddWalkRequestDto>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Walk, UpdateWalkRequestDto>().ReverseMap();


            /**
             * Difficulty
             * */
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();

        }
    }
}
