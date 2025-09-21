using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class CommentRepository : AbstractRepository<Comment>, ICommentRepository
{
    public CommentRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }
    
    public override IEnumerable<Comment> GetAll()
    {
        return Entity
            .Include(hm => hm.HikingTrail)
            .ToList();
    }

    public override async Task<IEnumerable<Comment>> GetAllAsync()
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .ToListAsync();    }
    
    public override async Task<IPaged<Comment>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .ToPageAsync(filter, cancellationToken);
    }

    public override Comment? Get(int id)
    {
        return Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefault(hm => hm.Id == id);
    }

    public override async Task<Comment?> GetAsync(int id)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefaultAsync(hm => hm.Id == id);
    }

    public override Comment? GetByCode(Guid code)
    {
        return Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefault(hm => hm.Code == code);
    }

    public override async Task<Comment?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefaultAsync(hm => hm.Code == code);
    }
    
}