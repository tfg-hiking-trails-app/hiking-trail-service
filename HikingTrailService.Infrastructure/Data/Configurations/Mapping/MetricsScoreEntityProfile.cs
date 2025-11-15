using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class MetricsScoreEntityProfile : Profile
{
    public MetricsScoreEntityProfile()
    {
        CreateMap<MetricsScoreEntityDto, MetricsScore>().ReverseMap();
        CreateMap<CreateMetricsScoreEntityDto, MetricsScore>().ReverseMap();
        CreateMap<UpdateMetricsScoreEntityDto, MetricsScore>().ReverseMap();
    }
}