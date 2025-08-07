using Common.Infrastructure.Data.Configuration.Entities;
using HikingTrailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingTrailService.Infrastructure.Data.Configurations.Entities;

public class TrailTypeConfiguration : EntityConfiguration<TrailType>
{
    public override void Configure(EntityTypeBuilder<TrailType> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("TrailType");
        
        builder.Property(d => d.Trail)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("terrain");
        
        builder.HasMany(d => d.HikingTrails)
            .WithOne(h => h.TrailType)
            .HasForeignKey(h => h.TrailTypeId);
    }
}