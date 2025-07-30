using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class HealthMetricsEntityProfile : Profile
{
    public HealthMetricsEntityProfile()
    {
        CreateMap<HealthMetricsEntityDto, HealthMetrics>().ReverseMap();
    }
}