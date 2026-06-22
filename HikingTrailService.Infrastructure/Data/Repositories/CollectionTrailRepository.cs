using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class CollectionTrailRepository : AbstractRepository<CollectionTrail>, ICollectionTrailRepository
{
    public CollectionTrailRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IPaged<HikingTrail>> GetTrailsByCollectionPaged(
        int collectionId,
        FilterData filterData,
        CancellationToken cancellationToken)
    {
        IQueryable<int> trailIds = Entity
            .Where(ct => ct.CollectionId == collectionId)
            .Select(ct => ct.HikingTrailId);

        return await DbContext.Set<HikingTrail>()
            .Where(h => !h.Deleted && trailIds.Contains(h.Id))
            .AsNoTracking()
            .Include(h => h.DifficultyLevel)
            .Include(h => h.TerrainType)
            .Include(h => h.TrailType)
            .Include(h => h.Metrics)
            .Include(h => h.Images
                .Where(img => !img.Deleted)
                .OrderBy(img => img.OrderIndex))
            .Include(h => h.Prestiges)
            .Include(h => h.Comments)
            .Include(h => h.Locations)
            .AsSplitQuery()
            .ToPageAsync(filterData, cancellationToken);
    }

    public async Task<CollectionTrail?> GetByCollectionAndTrailAsync(int collectionId, int hikingTrailId)
    {
        return await Entity
            .FirstOrDefaultAsync(ct => ct.CollectionId == collectionId && ct.HikingTrailId == hikingTrailId);
    }

    public async Task<bool> ExistsByCollectionAndTrailAsync(int collectionId, int hikingTrailId)
    {
        return await Entity
            .AnyAsync(ct => ct.CollectionId == collectionId && ct.HikingTrailId == hikingTrailId);
    }

    public async Task<IEnumerable<Guid>> GetSavedTrailCodesByAccountAsync(Guid accountCode)
    {
        return await Entity
            .AsNoTracking()
            .Where(ct => ct.Collection!.AccountCode == accountCode && !ct.HikingTrail!.Deleted)
            .Select(ct => ct.HikingTrail!.Code)
            .Distinct()
            .ToListAsync();
    }
}
