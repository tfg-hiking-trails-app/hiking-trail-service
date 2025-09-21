using Common.Infrastructure.Data.Configuration.Entities;
using HikingTrailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingTrailService.Infrastructure.Data.Configurations.Entities;

public class PrestigeConfiguration : EntityConfiguration<Prestige>
{
    public override void Configure(EntityTypeBuilder<Prestige> builder)
    {
        base.Configure(builder);

        builder.ToTable("Prestiges");

        builder.HasOne(d => d.HikingTrail)
            .WithMany(h => h.Prestiges)
            .HasForeignKey(d => d.HikingTrailId);

        builder.Property(d => d.HikingTrailId)
            .HasColumnName("hiking_trail_id");

        builder.Property(d => d.ReceiverAccountCode)
            .IsRequired()
            .HasColumnName("receiver_account_code");
        
        builder.Property(d => d.GiverAccountCode)
            .IsRequired()
            .HasColumnName("giver_account_code");
    }
}