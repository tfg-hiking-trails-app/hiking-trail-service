using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Update;

namespace HikingTrailService.DTOs.Mapping;

public class TrailTypeProfile : Profile
{
    public TrailTypeProfile()
    {
        CreateMap<TerrainTypeDto, TerrainTypeEntityDto>().ReverseMap();
        CreateMap<CreateTerrainTypeDto, CreateTerrainTypeEntityDto>().ReverseMap();
        CreateMap<UpdateTerrainTypeDto, UpdateTerrainTypeEntityDto>().ReverseMap();
    }
}