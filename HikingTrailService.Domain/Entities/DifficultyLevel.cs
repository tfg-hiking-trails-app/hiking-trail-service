using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace HikingTrailService.Domain.Entities;

[Table("DifficultyLevel")]
public class DifficultyLevel : BaseEntity
{
    [Required]
    [MaxLength(50)]
    [Column("difficulty_level")]
    public string? DifficultyLevelValue { get; set; }
    
    public virtual ICollection<HikingTrail> HikingTrails { get; set; } = new List<HikingTrail>();
}