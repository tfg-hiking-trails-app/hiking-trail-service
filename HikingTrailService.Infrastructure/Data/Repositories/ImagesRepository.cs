using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class ImagesRepository : AbstractRepository<Images>, IImagesRepository
{
    public ImagesRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }
    
    public override IEnumerable<Images> GetAll()
    {
        return Entity
            .Include(i => i.HikingTrail)
            .OrderBy(i => i.HikingTrail.Name)
            .ThenBy(i => i.OrderIndex)
            .ToList();
    }

    public override async Task<IEnumerable<Images>> GetAllAsync()
    {
        return await Entity
            .Include(i => i.HikingTrail)
            .OrderBy(i => i.HikingTrail.Name)
            .ThenBy(i => i.OrderIndex)
            .ToListAsync();    }
    
    public override async Task<IPaged<Images>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(i => i.HikingTrail)
            .OrderBy(i => i.HikingTrail.Name)
            .ThenBy(i => i.OrderIndex)
            .ToPageAsync(filter, cancellationToken);
    }

    public override Images? Get(int id)
    {
        return Entity
            .Include(i => i.HikingTrail)
            .OrderBy(i => i.OrderIndex)
            .FirstOrDefault(i => i.Id == id);
    }
    
    public async Task<Images?> GetByHikingTrailIdAndImageUrlAsync(int hikingTrailId, string imageUrl)
    {
        return await Entity
            .Include(i => i.HikingTrail)
            .OrderBy(i => i.OrderIndex)
            .FirstOrDefaultAsync(i => i.HikingTrailId == hikingTrailId && 
                                       i.ImageUrl == imageUrl);
    }

    public override async Task<Images?> GetAsync(int id)
    {
        return await Entity
            .Include(i => i.HikingTrail)
            .OrderBy(i => i.OrderIndex)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public override Images? GetByCode(Guid code)
    {
        return Entity
            .Include(i => i.HikingTrail)
            .OrderBy(i => i.OrderIndex)
            .FirstOrDefault(i => i.Code == code);
    }

    public override async Task<Images?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(i => i.HikingTrail)
            .OrderBy(i => i.OrderIndex)
            .FirstOrDefaultAsync(i => i.Code == code);
    }
}