using Common.Domain.Filter;
using Common.Domain.Interfaces;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Domain.Interfaces;

public interface ICollectionTrailRepository : IRepository<CollectionTrail>
{
    Task<IPaged<HikingTrail>> GetTrailsByCollectionPaged(
        int collectionId,
        FilterData filterData,
        CancellationToken cancellationToken);

    Task<CollectionTrail?> GetByCollectionAndTrailAsync(int collectionId, int hikingTrailId);

    Task<bool> ExistsByCollectionAndTrailAsync(int collectionId, int hikingTrailId);

    Task<IEnumerable<Guid>> GetSavedTrailCodesByAccountAsync(Guid accountCode);
}
