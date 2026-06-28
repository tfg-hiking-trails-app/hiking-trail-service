using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Explore;
using HikingTrailService.Domain.Interfaces;
using HikingTrailService.Domain.Recommender;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class HikingTrailRepository : AbstractRepository<HikingTrail>, IHikingTrailRepository
{
    public HikingTrailRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }

    public override IEnumerable<HikingTrail> GetAll()
    {
        return Entity
            .Where(h => !h.Deleted)
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
            .Where(h => !h.Deleted)
            .ToList();
    }

    public override async Task<IEnumerable<HikingTrail>> GetAllAsync()
    {
        return await Entity
            .Where(h => !h.Deleted)
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
            .Where(h => !h.Deleted)
            .ToListAsync();
    }
    
    public override async Task<IPaged<HikingTrail>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Where(h => !h.Deleted)
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
            .Where(h => !h.Deleted)
            .ToPageAsync(filter, cancellationToken);
    }

    public override HikingTrail? Get(int id)
    {
        return Entity
            .Where(h => !h.Deleted)
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
            .FirstOrDefault(h => h.Id == id);
    }

    public override async Task<HikingTrail?> GetAsync(int id)
    {
        return await Entity
            .Where(h => !h.Deleted)
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
            .FirstOrDefaultAsync(h => h.Id == id);
    }

    public override HikingTrail? GetByCode(Guid code)
    {
        return Entity
            .Where(h => !h.Deleted)
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
            .FirstOrDefault(h => h.Code == code);
    }

    public override async Task<HikingTrail?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Where(h => !h.Deleted)
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
            .FirstOrDefaultAsync(h => h.Code == code);
    }

    public async Task<IPaged<HikingTrail>> GetByAccountCodesPaged(List<Guid> accountCodes, FilterData filterData, CancellationToken cancellationToken)
    {
        return await Entity
            .Where(h => !h.Deleted && accountCodes.Contains(h.AccountCode))
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
            .Where(h => !h.Deleted)
            .ToPageAsync(filterData, cancellationToken);
    }

    public async Task<IPaged<HikingTrail>> GetNewestAsync(FilterData filterData, CancellationToken cancellationToken)
    {
        return await Entity
            .Where(h => !h.Deleted)
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
            .OrderByDescending(h => h.StartTime)
            .ThenByDescending(h => h.EndTime)
            .ToPageAsync(filterData, cancellationToken);
    }

    public async Task<IPaged<HikingTrail>> GetExploreAsync(
        ExploreCriteria criteria,
        FilterData filterData,
        CancellationToken cancellationToken)
    {
        IQueryable<HikingTrail> query = Entity
            .Where(h => !h.Deleted)
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
            .AsSplitQuery();

        if (criteria.PetFriendly)
            query = query.Where(h => h.PetFriendly);

        if (criteria.DifficultyLevelCode.HasValue)
            query = query.Where(h => h.DifficultyLevel != null
                && h.DifficultyLevel.Code == criteria.DifficultyLevelCode.Value);

        if (criteria.TerrainTypeCode.HasValue)
            query = query.Where(h => h.TerrainType != null
                && h.TerrainType.Code == criteria.TerrainTypeCode.Value);

        if (criteria.TrailTypeCode.HasValue)
            query = query.Where(h => h.TrailType != null
                && h.TrailType.Code == criteria.TrailTypeCode.Value);

        if (criteria.MaxDistance.HasValue)
            query = query.Where(h =>
                h.Metrics.Sum(m => m.Distance) <= criteria.MaxDistance.Value);

        if (criteria.MaxElevationGain.HasValue)
            query = query.Where(h =>
                h.Metrics.Sum(m => m.ElevationGain ?? 0) <= criteria.MaxElevationGain.Value);

        if (criteria.MaxAltitude.HasValue)
            query = query.Where(h =>
                h.Metrics.Max(m => m.MaxAltitude) <= criteria.MaxAltitude.Value);

        if (criteria.StartTimeFrom.HasValue)
            query = query.Where(h => h.StartTime >= criteria.StartTimeFrom.Value);

        query = criteria.SortMode switch
        {
            ExploreSortMode.MostPrestigious => query
                .OrderByDescending(h => h.Prestiges.Count)
                .ThenByDescending(h => h.StartTime)
                .ThenByDescending(h => h.Id),
            ExploreSortMode.Longest => query
                .OrderByDescending(h => h.Metrics.Sum(m => m.Distance))
                .ThenByDescending(h => h.StartTime)
                .ThenByDescending(h => h.Id),
            _ => query
                .OrderByDescending(h => h.StartTime)
                .ThenByDescending(h => h.EndTime)
                .ThenByDescending(h => h.Id)
        };

        FilterData pageFilter = filterData with { SortField = null };

        return await query.ToPageAsync(pageFilter, cancellationToken);
    }

    public async Task<IList<HikingTrail>> RecommenderAsync(RecommenderData recommenderData, FilterData filterData, CancellationToken cancellationToken)
    {
        var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
        
        Point center = geometryFactory.CreatePoint(
            new Coordinate(recommenderData.LocationLongitude, recommenderData.LocationLatitude));

        double radius = recommenderData.Kilometers * 1000.0; // on meters
        
        return await Entity
            .Where(h => !h.Deleted && h.Location != null)
            .Where(h => h.Location!.Distance(center) <= radius)
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
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<HikingTrail>> SearcherAsync(string search, int numberResults)
    {
        return await Entity
            .Where(h => !h.Deleted)
            .Where(h => h.Name.ToLower().Contains(search.ToLower()))
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
            .OrderBy(h => h.Name)
            .Take(numberResults)
            .ToListAsync();
    }
    
}