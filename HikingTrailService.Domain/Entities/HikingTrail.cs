using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace HikingTrailService.Domain.Entities;

[Table("HikingTrail")]
public class HikingTrail : BaseEntity
{
    [Required]
    [Column("user_code")]
    public Guid UserCode { get; set; }
    
    [Column("difficulty_level_id")]
    public int? DifficultyLevelId { get; set; }
    
    [ForeignKey("DifficultyLevelId")]
    public DifficultyLevel? DifficultyLevel { get; set; }
    
    [Column("terrain_type_id")]
    public int? TerrainTypeId { get; set; }
    
    [ForeignKey("TerrainTypeId")]
    public TerrainType? TerrainType { get; set; }
    
    [Column("trail_type_id")]
    public int? TrailTypeId { get; set; }
    
    [ForeignKey("TrailTypeId")]
    public TrailType? TrailType { get; set; }
    
    [Required]
    [MaxLength(100)]
    [Column("name")]
    public required string Name { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("pet_friendly")]
    public bool PetFriendly { get; set; }
    
    [Required]
    [Column("start_time")]
    public required DateTime StartTime { get; set; }
    
    [Required]
    [Column("end_time")]
    public required DateTime EndTime { get; set; }
    
    [Required]
    [Column("ubication_latitude")]
    public required double UbicationLatitude { get; set; }
    
    [Required]
    [Column("ubication_longitude")]
    public required double UbicationLongitude { get; set; }
    
    [Column("deleted")]
    public bool Deleted { get; set; }
    
    [Column("generated_by_fit_file")]
    public bool GeneratedByFitFile { get; set; }
    
    public virtual ICollection<Metrics> Metrics { get; set; } = new List<Metrics>();
    public virtual ICollection<Images> Images { get; set; } = new List<Images>();
}