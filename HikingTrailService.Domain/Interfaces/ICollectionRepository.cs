using Common.Domain.Interfaces;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Domain.Interfaces;

public interface ICollectionRepository : IRepository<Collection>
{
    Task<IEnumerable<Collection>> GetByAccountCodeAsync(Guid accountCode);

    Task<Collection?> GetDefaultByAccountCodeAsync(Guid accountCode);

    Task<bool> ExistsByAccountCodeAndNameAsync(Guid accountCode, string name);
}
