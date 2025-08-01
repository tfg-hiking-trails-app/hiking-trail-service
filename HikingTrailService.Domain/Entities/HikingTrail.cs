using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace HikingTrailService.Domain.Entities;

[Table("HikingTrail")]
public class HikingTrail : BaseEntity
{
    [Required]
    [Column("difficulty_level_id")]
    public int DifficultyLevelId { get; set; }
    
    [ForeignKey("DifficultyLevelId")]
    public DifficultyLevel? DifficultyLevel { get; set; }
    
    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string? Name { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Required]
    [Column("distance")]
    public double Distance { get; set; }
    
    [Column("lowest_elevation")]
    public int LowestElevation { get; set; }
    
    [Column("highest_elevation")]
    public int HighestElevation { get; set; }
    
    [Column("start_time")]
    public DateTime? StartTime { get; set; }
    
    [Column("end_time")]
    public DateTime? EndTime { get; set; }
    
    [Required]
    [MaxLength(255)]
    [Column("ubication")]
    public string? Ubication { get; set; }
    
    [Column("pet_friendly")]
    public bool PetFriendly { get; set; }
    
    public virtual ICollection<HealthMetrics> HealthMetrics { get; set; } = new List<HealthMetrics>();
}