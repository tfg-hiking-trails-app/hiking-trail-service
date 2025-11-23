using Common.Domain.Interfaces;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Domain.Interfaces;

public interface IMetricsScoreRepository : IRepository<MetricsScore>
{
    MetricsScore? GetByAccountCode(Guid accountCode);
    
    Task<MetricsScore?> GetByAccountCodeAsync(Guid accountCode);
}