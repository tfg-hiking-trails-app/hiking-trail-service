using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace HikingTrailService.Domain.Entities;

[Table("Images")]
public class Images : BaseEntity
{
    [Required]
    [Column("hiking_trail_id")]
    public int HikingTrailId { get; set; }
    
    [ForeignKey("HikingTrailId")]
    public required HikingTrail HikingTrail { get; set; }
    
    [Required]
    [Column("image_url")]
    public required string ImageUrl { get; set; }
    
    [Column("order_index")]
    [DefaultValue(0)]
    public int OrderIndex { get; set; }
    
    [Column("deleted")]
    public bool Deleted { get; set; }
}