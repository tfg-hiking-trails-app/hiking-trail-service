using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class CollectionRepository : AbstractRepository<Collection>, ICollectionRepository
{
    public CollectionRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }

    public override Collection? GetByCode(Guid code)
    {
        return Entity
            .Include(c => c.CollectionTrails)
            .FirstOrDefault(c => c.Code == code);
    }

    public override async Task<Collection?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(c => c.CollectionTrails)
            .FirstOrDefaultAsync(c => c.Code == code);
    }

    public async Task<IEnumerable<Collection>> GetByAccountCodeAsync(Guid accountCode)
    {
        return await Entity
            .AsNoTracking()
            .Include(c => c.CollectionTrails)
            .Where(c => c.AccountCode == accountCode)
            .OrderByDescending(c => c.IsDefault)
            .ThenBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<Collection?> GetDefaultByAccountCodeAsync(Guid accountCode)
    {
        return await Entity
            .FirstOrDefaultAsync(c => c.AccountCode == accountCode && c.IsDefault);
    }

    public async Task<bool> ExistsByAccountCodeAndNameAsync(Guid accountCode, string name)
    {
        return await Entity
            .AnyAsync(c => c.AccountCode == accountCode && c.Name == name);
    }
}
