using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class HikingTrailRepository : AbstractRepository<HikingTrail>, IHikingTrailRepository
{
    public HikingTrailRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }

    public override IEnumerable<HikingTrail> GetAll()
    {
        return Entity
            .Include(hm => hm.DifficultyLevel)
            .Include(hm => hm.TerrainType)
            .Include(hm => hm.TrailType)
            .Include(hm => hm.Metrics)
            .Include(hm => hm.Images)
            .ToList();
    }

    public override async Task<IEnumerable<HikingTrail>> GetAllAsync()
    {
        return await Entity
            .Include(hm => hm.DifficultyLevel)
            .Include(hm => hm.TerrainType)
            .Include(hm => hm.TrailType)
            .Include(hm => hm.Metrics)
            .Include(hm => hm.Images)
            .ToListAsync();    }
    
    public override async Task<IPaged<HikingTrail>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(hm => hm.DifficultyLevel)
            .Include(hm => hm.TerrainType)
            .Include(hm => hm.TrailType)
            .Include(hm => hm.Metrics)
            .Include(hm => hm.Images)
            .ToPageAsync(filter, cancellationToken);
    }

    public override HikingTrail? Get(int id)
    {
        return Entity
            .Include(hm => hm.DifficultyLevel)
            .Include(hm => hm.TerrainType)
            .Include(hm => hm.TrailType)
            .Include(hm => hm.Metrics)
            .Include(hm => hm.Images)
            .FirstOrDefault(hm => hm.Id == id);
    }

    public override async Task<HikingTrail?> GetAsync(int id)
    {
        return await Entity
            .Include(hm => hm.DifficultyLevel)
            .Include(hm => hm.TerrainType)
            .Include(hm => hm.TrailType)
            .Include(hm => hm.Metrics)
            .Include(hm => hm.Images)
            .FirstOrDefaultAsync(hm => hm.Id == id);
    }

    public override HikingTrail? GetByCode(Guid code)
    {
        return Entity
            .Include(hm => hm.DifficultyLevel)
            .Include(hm => hm.TerrainType)
            .Include(hm => hm.TrailType)
            .Include(hm => hm.Metrics)
            .Include(hm => hm.Images)
            .FirstOrDefault(hm => hm.Code == code);
    }

    public override async Task<HikingTrail?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(hm => hm.DifficultyLevel)
            .Include(hm => hm.TerrainType)
            .Include(hm => hm.TrailType)
            .Include(hm => hm.Metrics)
            .Include(hm => hm.Images)
            .FirstOrDefaultAsync(hm => hm.Code == code);
    }
    
}