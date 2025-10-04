using Common.Application.Interfaces;
using Common.Application.Pagination;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Filter;
using HikingTrailService.Application.DTOs.Update;

namespace HikingTrailService.Application.Interfaces;

public interface IHikingTrailService : IService<HikingTrailEntityDto, CreateHikingTrailEntityDto, UpdateHikingTrailEntityDto>
{
    Task<Page<HikingTrailEntityDto>> GetByAccountCodesPaged(
        HikingTrailFilterEntityDto filterEntityDto, 
        CancellationToken cancellationToken);
    
    Task<IEnumerable<HikingTrailEntityDto>> SearcherAsync(string search, int numberResults);

    Task LogicalDeleteAsync(Guid ownerAccountCode, Guid hikingTrailCode);
}