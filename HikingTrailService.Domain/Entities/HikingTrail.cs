using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;
using NetTopologySuite.Geometries;

namespace HikingTrailService.Domain.Entities;

[Table("HikingTrail")]
public class HikingTrail : BaseEntity
{
    [Required]
    [Column("account_code")]
    public Guid AccountCode { get; set; }
    
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
    [Column("location_latitude")]
    public required double LocationLatitude { get; set; }
    
    [Required]
    [Column("location_longitude")]
    public required double LocationLongitude { get; set; }
    
    [Column("location")]
    public Point? Location { get; set; }
    
    [Column("deleted")]
    public bool Deleted { get; set; }
    
    [Column("generated_by_fit_file")]
    public bool GeneratedByFitFile { get; set; }
    
    public virtual ICollection<Metrics> Metrics { get; set; } = new List<Metrics>();
    public virtual ICollection<Images> Images { get; set; } = new List<Images>();
    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
    public virtual ICollection<Prestige> Prestiges { get; set; } = new List<Prestige>();
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}