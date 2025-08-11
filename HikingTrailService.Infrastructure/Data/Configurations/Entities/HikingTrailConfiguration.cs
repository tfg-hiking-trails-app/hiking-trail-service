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

        builder.HasOne(h => h.DifficultyLevel)
            .WithMany(d => d.HikingTrails)
            .HasForeignKey(h => h.DifficultyLevelId);
        
        builder.HasMany(h => h.Metrics)
            .WithOne(m => m.HikingTrail)
            .HasForeignKey(m => m.HikingTrailId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(h => h.Images)
            .WithOne(i => i.HikingTrail)
            .HasForeignKey(i => i.HikingTrailId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(h => h.AccountCode)
            .IsRequired()
            .HasMaxLength(36)
            .HasColumnName("account_code");
        
        builder.Property(h => h.DifficultyLevelId)
            .HasColumnName("difficulty_level_id");

        builder.Property(h => h.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(h => h.Description)
            .HasColumnName("description");
        
        builder.Property(h => h.PetFriendly)
            .HasColumnName("pet_friendly");

        builder.Property(h => h.StartTime)
            .IsRequired()
            .HasColumnName("start_time");

        builder.Property(h => h.EndTime)
            .IsRequired()
            .HasColumnName("end_time");
        
        builder.Property(h => h.UbicationLatitude)
            .IsRequired()
            .HasColumnName("ubication_latitude");
        
        builder.Property(h => h.UbicationLongitude)
            .IsRequired()
            .HasColumnName("ubication_longitude");
        
        builder.Property(h => h.Deleted)
            .HasColumnName("deleted");
        
        builder.Property(h => h.GeneratedByFitFile)
            .HasColumnName("generated_by_fit_file");
    }
}