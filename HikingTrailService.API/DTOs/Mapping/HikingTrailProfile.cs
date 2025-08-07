using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Update;

namespace HikingTrailService.DTOs.Mapping;

public class HikingTrailProfile : Profile
{
    public HikingTrailProfile()
    {
        CreateMap<HikingTrailDto, HikingTrailEntityDto>().ReverseMap();
        CreateMap<CreateHikingTrailDto, CreateHikingTrailDto>().ReverseMap();
        CreateMap<UpdateHikingTrailDto, UpdateHikingTrailDto>().ReverseMap();
    }
}