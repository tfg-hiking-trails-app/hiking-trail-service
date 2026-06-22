using Common.Application.DTOs.Filter;
using Common.Application.Interfaces;
using Common.Application.Pagination;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;

namespace HikingTrailService.Application.Interfaces;

public interface ICollectionService : IService<CollectionEntityDto, CreateCollectionEntityDto, UpdateCollectionEntityDto>
{
    Task<IEnumerable<CollectionEntityDto>> GetByAccountCodeAsync(Guid accountCode);

    Task<CollectionEntityDto> GetByCodeForAccountAsync(Guid code, Guid accountCode);

    Task<Guid> RenameAsync(Guid code, Guid accountCode, string name);

    Task RemoveCollectionAsync(Guid code, Guid accountCode);

    Task<Page<HikingTrailEntityDto>> GetTrailsByCollectionPaged(
        Guid code,
        Guid accountCode,
        FilterEntityDto filter,
        CancellationToken cancellationToken);

    Task AddTrailAsync(Guid collectionCode, Guid accountCode, Guid hikingTrailCode);

    Task RemoveTrailAsync(Guid collectionCode, Guid accountCode, Guid hikingTrailCode);

    Task<IEnumerable<Guid>> GetSavedTrailCodesAsync(Guid accountCode);
}
