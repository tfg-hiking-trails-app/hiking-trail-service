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
            .Include(m => m.HikingTrail)
            .ToList();
    }

    public override async Task<IEnumerable<Metrics>> GetAllAsync()
    {
        return await Entity
            .Include(m => m.HikingTrail)
            .ToListAsync();    }
    
    public override async Task<IPaged<Metrics>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(m => m.HikingTrail)
            .ToPageAsync(filter, cancellationToken);
    }

    public override Metrics? Get(int id)
    {
        return Entity
            .Include(m => m.HikingTrail)
            .FirstOrDefault(m => m.Id == id);
    }

    public override async Task<Metrics?> GetAsync(int id)
    {
        return await Entity
            .Include(m => m.HikingTrail)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public override Metrics? GetByCode(Guid code)
    {
        return Entity
            .Include(m => m.HikingTrail)
            .FirstOrDefault(m => m.Code == code);
    }

    public override async Task<Metrics?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(m => m.HikingTrail)
            .FirstOrDefaultAsync(m => m.Code == code);
    }
    
}