using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Filter;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Filter;
using HikingTrailService.DTOs.Update;

namespace HikingTrailService.DTOs.Mapping;

public class HikingTrailProfile : Profile
{
    public HikingTrailProfile()
    {
        CreateMap<HikingTrailDto, HikingTrailEntityDto>().ReverseMap();
        CreateMap<CreateHikingTrailDto, CreateHikingTrailEntityDto>().ReverseMap();
        CreateMap<UpdateHikingTrailDto, UpdateHikingTrailEntityDto>().ReverseMap();

        CreateMap<HikingTrailFilterDto, HikingTrailFilterEntityDto>().ReverseMap();
    }
}