using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace HikingTrailService.Domain.Entities;

[Table("CollectionTrail")]
public class CollectionTrail : BaseEntity
{
    [Required]
    [Column("collection_id")]
    public int CollectionId { get; set; }

    [ForeignKey(nameof(CollectionId))]
    public Collection? Collection { get; set; }

    [Required]
    [Column("hiking_trail_id")]
    public int HikingTrailId { get; set; }

    [ForeignKey(nameof(HikingTrailId))]
    public HikingTrail? HikingTrail { get; set; }
}
