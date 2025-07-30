using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class DifficultyLevelEntityProfile : Profile
{
    public DifficultyLevelEntityProfile()
    {
        CreateMap<DifficultyLevelEntityDto, DifficultyLevel>().ReverseMap();
    }
}