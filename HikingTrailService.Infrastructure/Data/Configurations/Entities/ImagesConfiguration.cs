using Common.Infrastructure.Data.Configuration.Entities;
using HikingTrailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingTrailService.Infrastructure.Data.Configurations.Entities;

public class ImagesConfiguration : EntityConfiguration<Images>
{
    public override void Configure(EntityTypeBuilder<Images> builder)
    {
        base.Configure(builder);

        builder.ToTable("Images");

        builder.HasOne(d => d.HikingTrail)
            .WithMany(h => h.Images)
            .HasForeignKey(d => d.HikingTrailId);

        builder.Property(d => d.HikingTrailId)
            .HasColumnName("hiking_trail_id");

        builder.Property(d => d.ImageUrl)
            .IsRequired()
            .HasColumnName("image_url");
        
        builder.Property(d => d.OrderIndex)
            .HasDefaultValue(0)
            .HasColumnName("order_index");
        
        builder.Property(h => h.Deleted)
            .HasColumnName("deleted");
    }
}