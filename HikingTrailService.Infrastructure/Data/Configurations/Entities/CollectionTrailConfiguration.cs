using Common.Infrastructure.Data.Configuration.Entities;
using HikingTrailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingTrailService.Infrastructure.Data.Configurations.Entities;

public class CollectionTrailConfiguration : EntityConfiguration<CollectionTrail>
{
    public override void Configure(EntityTypeBuilder<CollectionTrail> builder)
    {
        base.Configure(builder);

        builder.ToTable("CollectionTrail");

        builder.HasOne(ct => ct.Collection)
            .WithMany(c => c.CollectionTrails)
            .HasForeignKey(ct => ct.CollectionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(ct => ct.CollectionId)
            .HasColumnName("collection_id");

        builder.HasOne(ct => ct.HikingTrail)
            .WithMany()
            .HasForeignKey(ct => ct.HikingTrailId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(ct => ct.HikingTrailId)
            .HasColumnName("hiking_trail_id");
    }
}
