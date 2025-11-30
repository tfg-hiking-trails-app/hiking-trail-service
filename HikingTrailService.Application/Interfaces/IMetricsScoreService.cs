using Common.Application.Interfaces;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;

namespace HikingTrailService.Application.Interfaces;

public interface IMetricsScoreService : IService<MetricsScoreEntityDto, CreateMetricsScoreEntityDto, UpdateMetricsScoreEntityDto>
{
    MetricsScoreEntityDto GetByAccountCode(Guid accountCode);
    
    Task<MetricsScoreEntityDto> GetByAccountCodeAsync(Guid accountCode);
    
    Task<MetricsScoreEntityDto> UpsertByAccountCodeAsync(UpdateMetricsScoreEntityDto updateDto);
}