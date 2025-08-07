using Common.Infrastructure.Data.Configuration.Entities;
using HikingTrailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingTrailService.Infrastructure.Data.Configurations.Entities;

public class MetricsConfiguration : EntityConfiguration<Metrics>
{
    public override void Configure(EntityTypeBuilder<Metrics> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Metrics");

        builder.HasOne(d => d.HikingTrail)
            .WithMany(h => h.Metrics)
            .HasForeignKey(d => d.HikingTrailId);

        builder.Property(d => d.HikingTrailId)
            .HasColumnName("hiking_trail_id");

        builder.Property(d => d.Distance)
            .IsRequired()
            .HasColumnName("distance");

        builder.Property(d => d.Duration)
            .HasColumnName("duration");

        builder.Property(d => d.Steps)
            .HasColumnName("steps");

        builder.Property(d => d.Calories)
            .HasColumnName("calories");

        builder.Property(d => d.AveragePace)
            .HasColumnName("average_pace");

        builder.Property(d => d.MaxPace)
            .HasColumnName("max_pace");

        builder.Property(d => d.ElevationGain)
            .HasColumnName("elevation_gain");

        builder.Property(d => d.ElevationLoss)
            .HasColumnName("elevation_loss");

        builder.Property(d => d.AverageSpeed)
            .HasColumnName("average_speed");

        builder.Property(d => d.MaxSpeed)
            .HasColumnName("max_speed");

        builder.Property(d => d.AverageHeartRate)
            .HasColumnName("average_heart_rate");

        builder.Property(d => d.MaxHeartRate)
            .HasColumnName("max_heart_rate");

        builder.Property(d => d.MinHeartRate)
            .HasColumnName("min_heart_rate");

        builder.Property(d => d.AverageCadence)
            .HasColumnName("average_cadence");

        builder.Property(d => d.MaxCadence)
            .HasColumnName("max_cadence");

        builder.Property(d => d.MaxAltitude)
            .HasColumnName("max_altitude");

        builder.Property(d => d.MinAltitude)
            .HasColumnName("min_altitude");

        builder.Property(d => d.TotalTrainingEffect)
            .HasColumnName("total_training_effect");

        builder.Property(d => d.TrainingStressScore)
            .HasColumnName("training_stress_score");
    }
}