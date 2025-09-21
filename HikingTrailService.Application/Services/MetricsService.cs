using AutoMapper;
using Common.Application.Services;
using Common.Application.Utils;
using Common.Domain.Exceptions;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Application.Services;

public class MetricsService : AbstractService<Metrics, MetricsEntityDto, CreateMetricsEntityDto, 
    UpdateMetricsEntityDto>, IMetricsService
{
    private readonly IHikingTrailRepository _hikingTrailRepository;
    
    public MetricsService(
        IMetricsRepository metricsHikingTrailRepository, 
        IHikingTrailRepository hikingTrailRepository,
        IMapper mapper) : base(metricsHikingTrailRepository, mapper)
    {
        _hikingTrailRepository = hikingTrailRepository;
    }
    
    public override async Task<Guid> CreateAsync(CreateMetricsEntityDto createEntityDto)
    {
        CheckDataValidity(createEntityDto);
        
        Metrics metrics = Mapper.Map<Metrics>(createEntityDto);

        HikingTrail? hikingTrail = await _hikingTrailRepository.GetByCodeAsync(createEntityDto.HikingTrailCode);
        
        if (hikingTrail is null)
            throw new NotFoundEntityException(nameof(HikingTrail), createEntityDto.HikingTrailCode);
        
        metrics.Code = Guid.NewGuid();
        metrics.HikingTrailId = hikingTrail.Id;

        await Repository.AddAsync(metrics);

        return metrics.Code;
    }

    protected override void CheckDataValidity(CreateMetricsEntityDto createEntityDto)
    {
        Validator.CheckPositiveValue(createEntityDto.Distance, nameof(createEntityDto.Distance));
    }
    
}