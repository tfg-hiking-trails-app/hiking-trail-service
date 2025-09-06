using Common.Infrastructure.Data.Configuration.Entities;
using HikingTrailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingTrailService.Infrastructure.Data.Configurations.Entities;

public class LocationConfiguration : EntityConfiguration<Location>
{
    public override void Configure(EntityTypeBuilder<Location> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Location");

        builder.HasOne(l => l.HikingTrail)
            .WithMany(h => h.Locations)
            .HasForeignKey(l => l.HikingTrailId);

        builder.Property(l => l.HikingTrailId)
            .HasColumnName("hiking_trail_id");

        builder.Property(l => l.Country)
            .HasMaxLength(100)
            .HasColumnName("country");

        builder.Property(l => l.CountryCode)
            .HasMaxLength(2)
            .HasColumnName("country_code");

        builder.Property(l => l.State)
            .HasMaxLength(100)
            .HasColumnName("state");

        builder.Property(l => l.StateCode)
            .HasMaxLength(10)
            .HasColumnName("state_code");

        builder.Property(l => l.County)
            .HasMaxLength(100)
            .HasColumnName("county");

        builder.Property(l => l.CountyCode)
            .HasMaxLength(10)
            .HasColumnName("county_code");

        builder.Property(l => l.City)
            .HasMaxLength(100)
            .HasColumnName("city");

        builder.Property(l => l.PostCode)
            .HasMaxLength(20)
            .HasColumnName("post_code");

        builder.Property(l => l.District)
            .HasMaxLength(100)
            .HasColumnName("district");

        builder.Property(l => l.Suburb)
            .HasMaxLength(100)
            .HasColumnName("suburb");

        builder.Property(l => l.Street)
            .HasMaxLength(100)
            .HasColumnName("street");

        builder.Property(l => l.HouseNumber)
            .HasColumnName("house_number");

        builder.Property(l => l.FormattedAddress)
            .HasMaxLength(255)
            .HasColumnName("formatted_address");

        builder.Property(l => l.AddressLine1)
            .HasMaxLength(255)
            .HasColumnName("address_line1");

        builder.Property(l => l.AddressLine2)
            .HasMaxLength(255)
            .HasColumnName("address_line2");

        builder.Property(l => l.Category)
            .HasMaxLength(100)
            .HasColumnName("category");

        builder.Property(l => l.ResultType)
            .HasMaxLength(50)
            .HasColumnName("result_type");

        builder.Property(l => l.Deleted)
            .HasColumnName("deleted");
    }
}