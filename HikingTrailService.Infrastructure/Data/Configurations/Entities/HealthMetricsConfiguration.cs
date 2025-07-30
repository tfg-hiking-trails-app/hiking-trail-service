using HikingTrailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingTrailService.Infrastructure.Data.Configurations.Entities;

public class HealthMetricsConfiguration : EntityConfiguration<HealthMetrics>
{
    public override void Configure(EntityTypeBuilder<HealthMetrics> builder)
    {
        base.Configure(builder);

        builder.ToTable("HealthMetrics");
        
        builder.HasOne(d => d.HikingTrail)
            .WithMany(h => h.HealthMetrics)
            .HasForeignKey(d => d.HikingTrailId);
        
        builder.Property(d => d.MaxHeartRate)
            .HasColumnName("min_heart_rate");
        
        builder.Property(d => d.MaxHeartRate)
            .IsRequired()
            .HasColumnName("max_heart_rate");

        builder.Property(d => d.AverageHeartRate)
            .IsRequired()
            .HasColumnName("average_heart_rate");

        builder.Property(d => d.CaloriesBurned)
            .IsRequired()
            .HasColumnName("calories_burned");

        builder.Property(d => d.Steps)
            .IsRequired()
            .HasColumnName("steps");

        builder.Property(d => d.ElevationGain)
            .IsRequired()
            .HasColumnName("elevation_gain");

        builder.Property(d => d.MinPace)
            .IsRequired()
            .HasColumnName("min_pace");

        builder.Property(d => d.MaxPace)
            .IsRequired()
            .HasColumnName("max_pace");

        builder.Property(d => d.AveragePace)
            .IsRequired()
            .HasColumnName("average_pace");

        builder.Property(d => d.MinSpeed)
            .IsRequired()
            .HasColumnName("min_speed");

        builder.Property(d => d.MaxSpeed)
            .IsRequired()
            .HasColumnName("max_speed");

        builder.Property(d => d.AverageSpeed)
            .IsRequired()
            .HasColumnName("average_speed");
    }
}