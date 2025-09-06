using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class LocationRepository :  AbstractRepository<Location>, ILocationRepository
{
    public LocationRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }
    
    public override IEnumerable<Location> GetAll()
    {
        return Entity
            .Include(l => l.HikingTrail)
            .ToList();
    }

    public override async Task<IEnumerable<Location>> GetAllAsync()
    {
        return await Entity
            .Include(l => l.HikingTrail)
            .ToListAsync();    }
    
    public override async Task<IPaged<Location>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(l => l.HikingTrail)
            .ToPageAsync(filter, cancellationToken);
    }

    public override Location? Get(int id)
    {
        return Entity
            .Include(l => l.HikingTrail)
            .FirstOrDefault(l => l.Id == id);
    }

    public override async Task<Location?> GetAsync(int id)
    {
        return await Entity
            .Include(l => l.HikingTrail)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public override Location? GetByCode(Guid code)
    {
        return Entity
            .Include(l => l.HikingTrail)
            .FirstOrDefault(l => l.Code == code);
    }

    public override async Task<Location?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(l => l.HikingTrail)
            .FirstOrDefaultAsync(l => l.Code == code);
    }
    
}