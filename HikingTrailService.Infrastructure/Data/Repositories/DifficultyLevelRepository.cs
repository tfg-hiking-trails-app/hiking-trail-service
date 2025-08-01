using Common.Infrastructure.Data.Repositories;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class DifficultyLevelRepository : AbstractRepository<DifficultyLevel>, IDifficultyLevelRepository
{
    public DifficultyLevelRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }
}