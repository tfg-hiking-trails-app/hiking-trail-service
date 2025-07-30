using HikingTrailService.Application.Common.Pagination;
using HikingTrailService.Application.DTOs.Common;

namespace HikingTrailService.Application.Interfaces;

public interface IService<TEntityDto, TCreateEntityDto, TUpdateEntityDto>
{
    Task<IEnumerable<TEntityDto>> GetAllAsync();

    Task<Page<TEntityDto>> GetPagedAsync(FilterEntityDto filter, CancellationToken cancellationToken);
    
    Task<TEntityDto> GetByIdAsync(int id);
    
    Task<TEntityDto> GetByCodeAsync(Guid code);
    
    Task<Guid> CreateAsync(TCreateEntityDto entity);
    
    Task<Guid> UpdateAsync(TUpdateEntityDto entity);
    
    Task DeleteAsync(Guid code);
}