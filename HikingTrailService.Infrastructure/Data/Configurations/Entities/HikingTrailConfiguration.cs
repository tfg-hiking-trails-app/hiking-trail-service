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
            .HasColumnName("difficulty_level_id");

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(d => d.Description)
            .HasColumnName("description");
        
        builder.Property(d => d.PetFriendly)
            .HasColumnName("pet_friendly");

        builder.Property(d => d.StartTime)
            .IsRequired()
            .HasColumnName("start_time");

        builder.Property(d => d.EndTime)
            .IsRequired()
            .HasColumnName("end_time");
        
        builder.Property(d => d.UbicationLatitude)
            .IsRequired()
            .HasColumnName("ubication_latitude");
        
        builder.Property(d => d.UbicationLongitude)
            .IsRequired()
            .HasColumnName("ubication_longitude");
        
        builder.Property(d => d.Deleted)
            .HasColumnName("deleted");
        
        builder.Property(d => d.GeneratedByFitFile)
            .HasColumnName("generated_by_fit_file");
    }
}