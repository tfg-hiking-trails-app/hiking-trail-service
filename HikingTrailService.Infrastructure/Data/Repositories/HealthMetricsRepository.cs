using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class HealthMetricsRepository : AbstractRepository<HealthMetrics>, IHealthMetricsRepository
{
    public HealthMetricsRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }

    public override IEnumerable<HealthMetrics> GetAll()
    {
        return Entity
            .Include(hm => hm.HikingTrail)
            .ToList();
    }

    public override async Task<IEnumerable<HealthMetrics>> GetAllAsync()
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .ToListAsync();    }
    
    public override async Task<IPaged<HealthMetrics>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .ToPageAsync(filter, cancellationToken);
    }

    public override HealthMetrics? Get(int id)
    {
        return Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefault(hm => hm.Id == id);
    }

    public override async Task<HealthMetrics?> GetAsync(int id)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefaultAsync(hm => hm.Id == id);
    }

    public override HealthMetrics? GetByCode(Guid code)
    {
        return Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefault(hm => hm.Code == code);
    }

    public override async Task<HealthMetrics?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefaultAsync(hm => hm.Code == code);
    }
    
}