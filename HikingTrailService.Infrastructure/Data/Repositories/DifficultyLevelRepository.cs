using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces.Repositories;

namespace HikingTrailService.Infrastructure.Data.Repositories;

public class DifficultyLevelRepository : AbstractRepository<DifficultyLevel>, IDifficultyLevelRepository
{
    public DifficultyLevelRepository(HikingTrailServiceDbContext dbContext) : base(dbContext)
    {
    }
}