using Common.Domain.Interfaces;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Domain.Interfaces;

public interface IImagesRepository : IRepository<Images>
{
    Task<Images?> GetByHikingTrailIdAndImageUrlAsync(int hikingTrailId, string imageUrl);
    
}