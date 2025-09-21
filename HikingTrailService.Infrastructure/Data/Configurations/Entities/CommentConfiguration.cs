using Common.Infrastructure.Data.Configuration.Entities;
using HikingTrailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingTrailService.Infrastructure.Data.Configurations.Entities;

public class CommentConfiguration : EntityConfiguration<Comment>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        base.Configure(builder);

        builder.ToTable("Comments");

        builder.HasOne(d => d.HikingTrail)
            .WithMany(h => h.Comments)
            .HasForeignKey(d => d.HikingTrailId);

        builder.Property(d => d.HikingTrailId)
            .HasColumnName("hiking_trail_id");

        builder.Property(d => d.AccountCode)
            .IsRequired()
            .HasColumnName("account_code");
        
        builder.Property(d => d.CommentText)
            .IsRequired()
            .HasColumnName("comment");
    }
}