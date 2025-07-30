using HikingTrailService.Domain.Common;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Domain.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    IEnumerable<TEntity> GetAll();
    
    Task<IEnumerable<TEntity>> GetAllAsync();
    
    Task<IPaged<TEntity>> GetPagedAsync(FilterData filter, CancellationToken cancellationToken);
    
    TEntity? Get(int id);
    
    Task<TEntity?> GetAsync(int id);
    
    TEntity? GetByCode(Guid code);

    Task<TEntity?> GetByCodeAsync(Guid code);
    
    Task AddAsync(TEntity entity);
    
    Task UpdateAsync(Guid code, TEntity entity);
    
    Task DeleteAsync(Guid code);
    
    void SaveChanges();
    
    Task SaveChangesAsync();
}