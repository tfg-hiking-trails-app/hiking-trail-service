using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class MetricsEntityProfile : Profile
{
    public MetricsEntityProfile()
    {
        CreateMap<MetricsEntityDto, Metrics>().ReverseMap();
        CreateMap<CreateMetricsEntityDto, Metrics>().ReverseMap();
        CreateMap<UpdateMetricsEntityDto, Metrics>().ReverseMap();
    }
}