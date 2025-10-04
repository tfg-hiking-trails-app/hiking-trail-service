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
            .AsNoTracking()
            .Include(h => h.DifficultyLevel)
            .Include(h => h.TerrainType)
            .Include(h => h.TrailType)
            .Include(h => h.Metrics)
            .Include(h => h.Images)
            .Include(h => h.Prestiges)
            .Include(h => h.Comments)
            .Include(h => h.Locations)
            .AsSplitQuery()
            .Where(h => !h.Deleted)
            .ToList();
    }

    public override async Task<IEnumerable<HikingTrail>> GetAllAsync()
    {
        return await Entity
            .AsNoTracking()
            .Include(h => h.DifficultyLevel)
            .Include(h => h.TerrainType)
            .Include(h => h.TrailType)
            .Include(h => h.Metrics)
            .Include(h => h.Images)
            .Include(h => h.Prestiges)
            .Include(h => h.Comments)
            .Include(h => h.Locations)
            .AsSplitQuery()
            .Where(h => !h.Deleted)
            .ToListAsync();
    }
    
    public override async Task<IPaged<HikingTrail>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .AsNoTracking()
            .Include(h => h.DifficultyLevel)
            .Include(h => h.TerrainType)
            .Include(h => h.TrailType)
            .Include(h => h.Metrics)
            .Include(h => h.Images)
            .Include(h => h.Prestiges)
            .Include(h => h.Comments)
            .Include(h => h.Locations)
            .AsSplitQuery()
            .Where(h => !h.Deleted)
            .ToPageAsync(filter, cancellationToken);
    }

    public override HikingTrail? Get(int id)
    {
        return Entity
            .Include(h => h.DifficultyLevel)
            .Include(h => h.TerrainType)
            .Include(h => h.TrailType)
            .Include(h => h.Metrics)
            .Include(h => h.Images)
            .Include(h => h.Prestiges)
            .Include(h => h.Comments)
            .Include(h => h.Locations)
            .FirstOrDefault(h => h.Id == id);
    }

    public override async Task<HikingTrail?> GetAsync(int id)
    {
        return await Entity
            .Include(h => h.DifficultyLevel)
            .Include(h => h.TerrainType)
            .Include(h => h.TrailType)
            .Include(h => h.Metrics)
            .Include(h => h.Images)
            .Include(h => h.Prestiges)
            .Include(h => h.Comments)
            .Include(h => h.Locations)
            .FirstOrDefaultAsync(h => h.Id == id);
    }

    public override HikingTrail? GetByCode(Guid code)
    {
        return Entity
            .Include(h => h.DifficultyLevel)
            .Include(h => h.TerrainType)
            .Include(h => h.TrailType)
            .Include(h => h.Metrics)
            .Include(h => h.Images)
            .Include(h => h.Prestiges)
            .Include(h => h.Comments)
            .Include(h => h.Locations)
            .FirstOrDefault(h => h.Code == code);
    }

    public override async Task<HikingTrail?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(h => h.DifficultyLevel)
            .Include(h => h.TerrainType)
            .Include(h => h.TrailType)
            .Include(h => h.Metrics)
            .Include(h => h.Images)
            .Include(h => h.Prestiges)
            .Include(h => h.Comments)
            .Include(h => h.Locations)
            .FirstOrDefaultAsync(h => h.Code == code);
    }

    public async Task<IPaged<HikingTrail>> GetByAccountCodesPaged(List<Guid> accountCodes, FilterData filterData, CancellationToken cancellationToken)
    {
        return await Entity
            .Where(h => accountCodes.Contains(h.AccountCode))
            .AsNoTracking()
            .Include(h => h.DifficultyLevel)
            .Include(h => h.TerrainType)
            .Include(h => h.TrailType)
            .Include(h => h.Metrics)
            .Include(h => h.Images)
            .Include(h => h.Prestiges)
            .Include(h => h.Comments)
            .Include(h => h.Locations)
            .AsSplitQuery()
            .Where(h => !h.Deleted)
            .ToPageAsync(filterData, cancellationToken);
    }

    public async Task<IEnumerable<HikingTrail>> SearcherAsync(string search, int numberResults)
    {
        return await Entity
            .AsNoTracking()
            .Include(h => h.DifficultyLevel)
            .Include(h => h.TerrainType)
            .Include(h => h.TrailType)
            .Include(h => h.Metrics)
            .Include(h => h.Images)
            .Include(h => h.Prestiges)
            .Include(h => h.Comments)
            .Include(h => h.Locations)
            .AsSplitQuery()
            .Where(h => h.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase) && !h.Deleted)
            .OrderBy(h => h.Name)
            .Take(numberResults)
            .ToListAsync();
    }
    
}