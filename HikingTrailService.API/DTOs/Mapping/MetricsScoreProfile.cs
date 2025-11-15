using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Update;

namespace HikingTrailService.DTOs.Mapping;

public class MetricsScoreProfile : Profile
{
    public MetricsScoreProfile()
    {
        CreateMap<MetricsScoreDto, MetricsScoreEntityDto>().ReverseMap();
        CreateMap<CreateMetricsScoreDto, CreateMetricsScoreEntityDto>().ReverseMap();
        CreateMap<UpdateMetricsScoreDto, UpdateMetricsScoreEntityDto>().ReverseMap();
    }
}