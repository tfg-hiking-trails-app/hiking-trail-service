using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace HikingTrailService.Domain.Entities;

[Table("TrailType")]
public class TrailType : BaseEntity
{
    [Required]
    [MaxLength(100)]
    [Column("trail")]
    public required string Trail { get; set; }
    
    public virtual ICollection<HikingTrail> HikingTrails { get; set; } = new List<HikingTrail>();
}