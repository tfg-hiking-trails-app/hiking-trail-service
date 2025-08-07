using Common.Infrastructure.Data.Configuration.Entities;
using HikingTrailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingTrailService.Infrastructure.Data.Configurations.Entities;

public class TerrainTypeConfiguration : EntityConfiguration<TerrainType>
{
    public override void Configure(EntityTypeBuilder<TerrainType> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("TerrainType");
        
        builder.Property(d => d.Terrain)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("terrain");
        
        builder.HasMany(d => d.HikingTrails)
            .WithOne(h => h.TerrainType)
            .HasForeignKey(h => h.TerrainTypeId);
    }
}