using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class DifficultyLevelEntityProfile : Profile
{
    public DifficultyLevelEntityProfile()
    {
        CreateMap<DifficultyLevelEntityDto, DifficultyLevel>().ReverseMap();
        CreateMap<CreateDifficultyLevelEntityDto, DifficultyLevel>().ReverseMap();
        CreateMap<UpdateDifficultyLevelEntityDto, DifficultyLevel>().ReverseMap();
    }
}