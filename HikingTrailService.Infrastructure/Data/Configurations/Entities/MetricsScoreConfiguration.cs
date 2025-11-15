using Common.Infrastructure.Data.Configuration.Entities;
using HikingTrailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingTrailService.Infrastructure.Data.Configurations.Entities;

public class MetricsScoreConfiguration : EntityConfiguration<MetricsScore>
{
    public override void Configure(EntityTypeBuilder<MetricsScore> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("MetricsScore");

        builder.Property(d => d.AccountCode)
            .IsRequired()
            .HasColumnName("account_code");

        builder.Property(d => d.Distance)
            .HasColumnName("distance");

        builder.Property(d => d.Duration)
            .HasColumnName("duration");

        builder.Property(d => d.Steps)
            .HasColumnName("steps");

        builder.Property(d => d.Calories)
            .HasColumnName("calories");

        builder.Property(d => d.Pace)
            .HasColumnName("pace");

        builder.Property(d => d.Elevation)
            .HasColumnName("elevation");

        builder.Property(d => d.HeartRate)
            .HasColumnName("heart_rate");

        builder.Property(d => d.Speed)
            .HasColumnName("speed");
    }
}