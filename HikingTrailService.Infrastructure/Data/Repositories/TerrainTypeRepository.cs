using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class TerrainTypeRepository : AbstractRepository<TerrainType>, ITerrainTypeRepository
{
    public TerrainTypeRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }
}