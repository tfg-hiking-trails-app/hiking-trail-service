using Common.Infrastructure.Data.Configuration.Entities;
using HikingTrailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingTrailService.Infrastructure.Data.Configurations.Entities;

public class CollectionConfiguration : EntityConfiguration<Collection>
{
    public override void Configure(EntityTypeBuilder<Collection> builder)
    {
        base.Configure(builder);

        builder.ToTable("Collection");

        builder.Property(c => c.AccountCode)
            .IsRequired()
            .HasColumnName("account_code");

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(c => c.IsDefault)
            .HasColumnName("is_default");

        builder.HasMany(c => c.CollectionTrails)
            .WithOne(ct => ct.Collection)
            .HasForeignKey(ct => ct.CollectionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
