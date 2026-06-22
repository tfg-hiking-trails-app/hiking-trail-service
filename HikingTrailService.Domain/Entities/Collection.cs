using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace HikingTrailService.Domain.Entities;

[Table("Collection")]
public class Collection : BaseEntity
{
    [Required]
    [Column("account_code")]
    public Guid AccountCode { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("name")]
    public required string Name { get; set; }

    [Column("is_default")]
    public bool IsDefault { get; set; }

    public virtual ICollection<CollectionTrail> CollectionTrails { get; set; } = new List<CollectionTrail>();
}
