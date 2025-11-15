using AutoMapper;
using Common.Application.Services;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;
using Validator = Common.Application.Utils.Validator;

namespace HikingTrailService.Application.Services;

public class MetricsScoreService : AbstractService<MetricsScore, MetricsScoreEntityDto, 
    CreateMetricsScoreEntityDto, UpdateMetricsScoreEntityDto>, IMetricsScoreService
{
    public MetricsScoreService(
        IMetricsScoreRepository metricsScoreRepository,
        IMapper mapper) : base(metricsScoreRepository, mapper)
    {
    }

    protected override void CheckDataValidity(CreateMetricsScoreEntityDto createEntityDto)
    {
        Validator.CheckGuid(createEntityDto.AccountCode);
    }
}