using Common.Domain.Filter;
using Common.Domain.Interfaces;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Recommender;

namespace HikingTrailService.Domain.Interfaces;

public interface IHikingTrailRepository : IRepository<HikingTrail>
{
    Task<IPaged<HikingTrail>> GetByAccountCodesPaged (
        List<Guid> accountCodes, 
        FilterData filterData, 
        CancellationToken cancellationToken);

    Task<IPaged<HikingTrail>> GetNewestAsync(FilterData filterData, CancellationToken cancellationToken);
    
    Task<IList<HikingTrail>> RecommenderAsync(
        RecommenderData recommenderData, 
        FilterData filterData, 
        CancellationToken cancellationToken);
    
    Task<IEnumerable<HikingTrail>> SearcherAsync(string search, int numberResults);
}