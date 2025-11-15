using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class MetricsScoreRepository : AbstractRepository<MetricsScore>, IMetricsScoreRepository
{
    public MetricsScoreRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }
}