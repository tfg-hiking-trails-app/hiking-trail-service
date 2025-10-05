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
            .Include(hm => hm.HikingTrail)
            .ToList();
    }

    public override async Task<IEnumerable<Images>> GetAllAsync()
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .ToListAsync();    }
    
    public override async Task<IPaged<Images>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .ToPageAsync(filter, cancellationToken);
    }

    public override Images? Get(int id)
    {
        return Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefault(hm => hm.Id == id);
    }
    
    public async Task<Images?> GetByHikingTrailIdAndImageUrlAsync(int hikingTrailId, string imageUrl)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefaultAsync(hm => hm.HikingTrailId == hikingTrailId && 
                                       hm.ImageUrl == imageUrl);
    }

    public override async Task<Images?> GetAsync(int id)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefaultAsync(hm => hm.Id == id);
    }

    public override Images? GetByCode(Guid code)
    {
        return Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefault(hm => hm.Code == code);
    }

    public override async Task<Images?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefaultAsync(hm => hm.Code == code);
    }
}