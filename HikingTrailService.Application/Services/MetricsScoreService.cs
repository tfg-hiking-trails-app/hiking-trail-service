using AutoMapper;
using Common.Application.Services;
using Common.Domain.Exceptions;
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
    private readonly IMetricsScoreRepository _metricsScoreRepository;
    
    public MetricsScoreService(
        IMetricsScoreRepository metricsScoreRepository,
        IMapper mapper) : base(metricsScoreRepository, mapper)
    {
        _metricsScoreRepository = metricsScoreRepository;
    }

    protected override void CheckDataValidity(CreateMetricsScoreEntityDto createEntityDto)
    {
        Validator.CheckGuid(createEntityDto.AccountCode);
    }

    public MetricsScoreEntityDto GetByAccountCode(Guid accountCode)
    {
        MetricsScore? metricsScore = _metricsScoreRepository.GetByAccountCode(accountCode);

        if (metricsScore is null)
            throw new NotFoundEntityException(nameof(MetricsScore),nameof(MetricsScore.AccountCode), accountCode.ToString());
        
        return Mapper.Map<MetricsScoreEntityDto>(metricsScore);
    }

    public async Task<MetricsScoreEntityDto> GetByAccountCodeAsync(Guid accountCode)
    {
        MetricsScore? metricsScore = await _metricsScoreRepository.GetByAccountCodeAsync(accountCode);

        if (metricsScore is null)
            throw new NotFoundEntityException(nameof(MetricsScore),nameof(MetricsScore.AccountCode), accountCode.ToString());
        
        return Mapper.Map<MetricsScoreEntityDto>(metricsScore);
    }

    public async Task<MetricsScoreEntityDto> UpsertByAccountCodeAsync(UpdateMetricsScoreEntityDto updateDto)
    {
        MetricsScore? entity = await _metricsScoreRepository.GetByAccountCodeAsync(updateDto.AccountCode);

        // Insert
        if (entity is null)
        {
            entity = new MetricsScore
            {
                Code = Guid.NewGuid(),
                AccountCode = updateDto.AccountCode,
                Distance = updateDto.Distance,
                Duration = updateDto.Duration,
                Steps = updateDto.Steps,
                Calories = updateDto.Calories,
                Pace = updateDto.Pace,
                Elevation = updateDto.Elevation,
                HeartRate = updateDto.HeartRate,
                Speed = updateDto.Speed
            };
            
            await _metricsScoreRepository.AddAsync(entity);
            
            return Mapper.Map<MetricsScoreEntityDto>(entity);
        }
        
        // Update
        Mapper.Map(updateDto, entity);
            
        await _metricsScoreRepository.UpdateAsync(entity);
        
        return Mapper.Map<MetricsScoreEntityDto>(entity);
    }
}