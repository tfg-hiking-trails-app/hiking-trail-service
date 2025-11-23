using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HikingTrailService.Infrastructure.Data;

public class HikingTrailServiceDbContext : DbContext
{
    public HikingTrailServiceDbContext(DbContextOptions<HikingTrailServiceDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string defaultConnection = GetDefaultConnectionToDatabase();
        
        optionsBuilder
            .UseMySql(
                defaultConnection, 
                ServerVersion.AutoDetect(defaultConnection), 
                options => options.UseNetTopologySuite()
            )
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Searches for entities that implement an entity configuration
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
    
    private string GetDefaultConnectionToDatabase()
    {
        string server = Environment.GetEnvironmentVariable("APP_DB_HOST") ?? "";
        string database = Environment.GetEnvironmentVariable("APP_DB_NAME") ?? "";
        string user = Environment.GetEnvironmentVariable("APP_DB_USER") ?? "";
        string password = Environment.GetEnvironmentVariable("APP_DB_PASSWORD") ?? "";
            
        return $"Server={server};Database={database};User={user};Password={password};TreatTinyAsBoolean=true;";
    }
    
}