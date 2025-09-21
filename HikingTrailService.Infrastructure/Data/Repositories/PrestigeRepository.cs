using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class PrestigeRepository : AbstractRepository<Prestige>, IPrestigeRepository
{
    public PrestigeRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }
    
    public override IEnumerable<Prestige> GetAll()
    {
        return Entity
            .Include(hm => hm.HikingTrail)
            .ToList();
    }

    public override async Task<IEnumerable<Prestige>> GetAllAsync()
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .ToListAsync();    }
    
    public override async Task<IPaged<Prestige>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .ToPageAsync(filter, cancellationToken);
    }

    public override Prestige? Get(int id)
    {
        return Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefault(hm => hm.Id == id);
    }

    public override async Task<Prestige?> GetAsync(int id)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefaultAsync(hm => hm.Id == id);
    }

    public override Prestige? GetByCode(Guid code)
    {
        return Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefault(hm => hm.Code == code);
    }

    public override async Task<Prestige?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefaultAsync(hm => hm.Code == code);
    }

    public async Task<Prestige?> GetByCodeAccountsAndHikingTrailAsync(Prestige prestige)
    {
        return await Entity
            .Include(hm => hm.HikingTrail)
            .FirstOrDefaultAsync(hm => hm.HikingTrail.Code == prestige.HikingTrail.Code &&
                                       hm.ReceiverAccountCode == prestige.ReceiverAccountCode &&
                                       hm.GiverAccountCode == prestige.GiverAccountCode);
    }
}