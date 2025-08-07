using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Update;

namespace HikingTrailService.DTOs.Mapping;

public class MetricsProfile : Profile
{
    public MetricsProfile()
    {
        CreateMap<MetricsDto, MetricsEntityDto>().ReverseMap();
        CreateMap<CreateMetricsDto, CreateMetricsEntityDto>().ReverseMap();
        CreateMap<UpdateMetricsDto, UpdateMetricsEntityDto>().ReverseMap();
    }
}