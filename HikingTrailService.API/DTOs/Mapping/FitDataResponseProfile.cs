using AutoMapper;
using HikingTrailService.Application.DTOs;

namespace HikingTrailService.DTOs.Mapping;

public class FitDataResponseProfile : Profile
{
    public FitDataResponseProfile()
    {
        CreateMap<FitFileDataEntityDto, HikingTrailEntityDto>().ReverseMap();
        CreateMap<FitFileDataEntityDto, HealthMetricsEntityDto>().ReverseMap();
    }
}