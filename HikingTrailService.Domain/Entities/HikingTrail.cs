using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace HikingTrailService.Domain.Entities;

[Table("HikingTrail")]
public class HikingTrail : BaseEntity
{
    [Column("difficulty_level_id")]
    public int? DifficultyLevelId { get; set; }
    
    [ForeignKey("DifficultyLevelId")]
    public DifficultyLevel? DifficultyLevel { get; set; }
    
    [Required]
    [MaxLength(100)]
    [Column("name")]
    public required string Name { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Required]
    [Column("distance")]
    public required int Distance { get; set; }
    
    [Column("pet_friendly")]
    public bool PetFriendly { get; set; }
    
    [Required]
    [Column("start_time")]
    public required DateTime StartTime { get; set; }
    
    [Required]
    [Column("end_time")]
    public required DateTime EndTime { get; set; }
    
    [Required]
    [Column("duration")]
    public required double Duration { get; set; }
    
    [Required]
    [Column("ubication_latitude")]
    public required double UbicationLatitude { get; set; }
    
    [Required]
    [Column("ubication_longitude")]
    public required double UbicationLongitude { get; set; }
}