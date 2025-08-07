using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Messaging;
using HikingTrailService.Application.DTOs.Update;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class FitFileDataProfile : Profile
{
    public FitFileDataProfile()
    {
        CreateMap<FitFileDataEntityDto, HikingTrailEntityDto>()
            .ForMember(dest => dest.Code, opt => opt.MapFrom(
                src => src.HikingTrailCode))
            .ReverseMap();
        CreateMap<FitFileDataEntityDto, CreateHikingTrailEntityDto>()
            .ForMember(dest => dest.Code, opt => opt.MapFrom(
                src => src.HikingTrailCode))
            .ReverseMap();
        CreateMap<FitFileDataEntityDto, UpdateHikingTrailEntityDto>().ReverseMap();
        
        CreateMap<FitFileDataEntityDto, MetricsEntityDto>().ReverseMap();
        CreateMap<FitFileDataEntityDto, CreateMetricsEntityDto>().ReverseMap();
        CreateMap<FitFileDataEntityDto, UpdateMetricsEntityDto>().ReverseMap();
    }
}