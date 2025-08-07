using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class TrailTypeRepository : AbstractRepository<TrailType>, ITrailTypeRepository
{
    public TrailTypeRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }
}