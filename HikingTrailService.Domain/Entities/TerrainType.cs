using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace HikingTrailService.Domain.Entities;

[Table("TerrainType")]
public class TerrainType : BaseEntity
{
    [Required]
    [MaxLength(100)]
    [Column("terrain")]
    public required string Terrain { get; set; }
    
    public virtual ICollection<HikingTrail> HikingTrails { get; set; } = new List<HikingTrail>();
}