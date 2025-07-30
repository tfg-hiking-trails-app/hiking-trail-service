using AutoMapper;
using HikingTrailService.Application.DTOs;

namespace HikingTrailService.DTOs.Mapping;

public class DifficultyLevelProfile : Profile
{
    public DifficultyLevelProfile()
    {
        CreateMap<DifficultyLevelDto, DifficultyLevelEntityDto>().ReverseMap();
    }
}