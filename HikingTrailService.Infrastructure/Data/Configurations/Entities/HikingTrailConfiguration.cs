using Common.Infrastructure.Data.Configuration.Entities;
using HikingTrailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingTrailService.Infrastructure.Data.Configurations.Entities;

public class HikingTrailConfiguration : EntityConfiguration<HikingTrail>
{
    public override void Configure(EntityTypeBuilder<HikingTrail> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("HikingTrail");

        builder.HasOne(d => d.DifficultyLevel)
            .WithMany(h => h.HikingTrails)
            .HasForeignKey(d => d.DifficultyLevelId);

        builder.Property(d => d.DifficultyLevelId)
            .IsRequired()
            .HasColumnName("difficulty_level_id");

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(d => d.Description)
            .HasColumnName("description");

        builder.Property(d => d.Distance)
            .IsRequired()
            .HasColumnName("distance");

        builder.Property(d => d.LowestElevation)
            .HasColumnName("lowest_elevation");

        builder.Property(d => d.HighestElevation)
            .HasColumnName("highest_elevation");

        builder.Property(d => d.StartTime)
            .HasColumnName("start_time");

        builder.Property(d => d.EndTime)
            .HasColumnName("end_time");

        builder.Property(d => d.Ubication)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("ubication");

        builder.Property(d => d.PetFriendly)
            .HasColumnName("pet_friendly");

        builder.HasMany(d => d.HealthMetrics)
            .WithOne(hm => hm.HikingTrail)
            .HasForeignKey(hm => hm.HikingTrailId);
    }
}