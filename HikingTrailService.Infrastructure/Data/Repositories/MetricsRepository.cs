using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class MetricsRepository : AbstractRepository<Metrics>, IMetricsRepository
{
    public MetricsRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }
    
    public override IEnumerable<Metrics> GetAll()
    {
        return Entity
            .Include(hm => hm.HikingTrail)
            .ToList();
    }

    public override async Task<IEnumerable<Metrics>> GetAllAsync()
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .ToListAsync();    }
    
    public override async Task<IPaged<Metrics>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .ToPageAsync(filter, cancellationToken);
    }

    public override Metrics? Get(int id)
    {
        return Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefault(hm => hm.Id == id);
    }

    public override async Task<Metrics?> GetAsync(int id)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefaultAsync(hm => hm.Id == id);
    }

    public override Metrics? GetByCode(Guid code)
    {
        return Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefault(hm => hm.Code == code);
    }

    public override async Task<Metrics?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefaultAsync(hm => hm.Code == code);
    }
    
}