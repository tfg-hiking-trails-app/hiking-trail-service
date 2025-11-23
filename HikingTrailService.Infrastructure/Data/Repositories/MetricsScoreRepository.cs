using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class MetricsScoreRepository : AbstractRepository<MetricsScore>, IMetricsScoreRepository
{
    public MetricsScoreRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }

    public MetricsScore? GetByAccountCode(Guid accountCode)
    {
        return Entity
            .SingleOrDefault(ms => ms.AccountCode == accountCode);
    }

    public async Task<MetricsScore?> GetByAccountCodeAsync(Guid accountCode)
    {
        return await Entity
            .SingleOrDefaultAsync(ms => ms.AccountCode == accountCode);
    }
}