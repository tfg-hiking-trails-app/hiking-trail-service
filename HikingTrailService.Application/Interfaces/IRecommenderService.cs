using Common.Application.DTOs.Filter;
using Common.Application.Pagination;
using HikingTrailService.Application.DTOs;

namespace HikingTrailService.Application.Interfaces;

public interface IRecommenderService
{
    Task<Page<HikingTrailEntityDto>> RecommenderAsync(
        Guid accountCode, 
        List<HikingTrailEntityDto> hikingTrails, 
        FilterEntityDto filterEntityDto,
        CancellationToken cancellationToken);
}