using AutoMapper;
using HikingTrailService.Application.DTOs;

namespace HikingTrailService.DTOs.Mapping;

public class FitDataResponseProfile : Profile
{
    public FitDataResponseProfile()
    {
        CreateMap<FitDataResponseDto, HikingTrailEntityDto>().ReverseMap();
        CreateMap<FitDataResponseDto, HealthMetricsEntityDto>().ReverseMap();
    }
}