using Common.Infrastructure.Data.Configuration.Entities;
using HikingTrailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingTrailService.Infrastructure.Data.Configurations.Entities;

public class DifficultyLevelConfiguration : EntityConfiguration<DifficultyLevel>
{
    public override void Configure(EntityTypeBuilder<DifficultyLevel> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("DifficultyLevel");
        
        builder.Property(d => d.DifficultyLevelValue)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("difficulty_level");
        
        builder.HasMany(d => d.HikingTrails)
            .WithOne(h => h.DifficultyLevel)
            .HasForeignKey(h => h.DifficultyLevelId);
    }
}