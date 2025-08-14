using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HikingTrailService.Infrastructure.Data;

public class HikingTrailServiceDbContext : AbstractDbContext
{
    public HikingTrailServiceDbContext(DbContextOptions<HikingTrailServiceDbContext> options)
        : base(options)
    {
    }
}