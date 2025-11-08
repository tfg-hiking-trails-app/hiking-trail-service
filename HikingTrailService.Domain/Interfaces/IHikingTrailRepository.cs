using Common.Domain.Filter;
using Common.Domain.Interfaces;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Domain.Interfaces;

public interface IHikingTrailRepository : IRepository<HikingTrail>
{
    Task<IPaged<HikingTrail>> GetByAccountCodesPaged (
        List<Guid> accountCodes, 
        FilterData filterData, 
        CancellationToken cancellationToken);

    Task<IPaged<HikingTrail>> GetNewest(FilterData filterData, CancellationToken cancellationToken);
    
    Task<IEnumerable<HikingTrail>> SearcherAsync(string search, int numberResults);
}