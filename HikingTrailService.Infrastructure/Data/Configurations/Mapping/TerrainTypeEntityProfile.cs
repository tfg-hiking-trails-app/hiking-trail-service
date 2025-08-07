using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class TerrainTypeEntityProfile : Profile
{
    public TerrainTypeEntityProfile()
    {
        CreateMap<TerrainTypeEntityDto, TerrainType>().ReverseMap();
        CreateMap<CreateTerrainTypeEntityDto, TerrainType>().ReverseMap();
        CreateMap<UpdateTerrainTypeEntityDto, TerrainType>().ReverseMap();
    }
}