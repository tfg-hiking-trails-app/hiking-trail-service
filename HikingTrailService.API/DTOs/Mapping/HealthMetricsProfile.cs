using AutoMapper;
using HikingTrailService.Application.DTOs;

namespace HikingTrailService.DTOs.Mapping;

public class HealthMetricsProfile : Profile
{
    public HealthMetricsProfile()
    {
        CreateMap<HealthMetricsDto, HealthMetricsEntityDto>().ReverseMap();
    }
}