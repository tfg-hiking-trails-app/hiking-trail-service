using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HikingTrailService.Domain.Entities;

[Table("HealthMetrics")]
public class HealthMetrics : BaseEntity
{
    [Required]
    [Column("hiking_trail_id")]
    public int HikingTrailId { get; set; }
    
    [ForeignKey("HikingTrailId")]
    public HikingTrail? HikingTrail { get; set; }
    
    [Column("min_heart_rate")]
    public int MinHeartRate { get; set; }
    
    [Column("max_heart_rate")]
    public int MaxHeartRate { get; set; }
    
    [Column("average_heart_rate")]
    public int AverageHeartRate { get; set; }
    
    [Column("calories_burned")]
    public int CaloriesBurned { get; set; }
    
    [Column("steps")]
    public int Steps { get; set; }
    
    [Column("elevation_gain")]
    public int ElevationGain { get; set; }
    
    [Column("min_pace")]
    public double MinPace { get; set; }
    
    [Column("max_pace")]
    public double MaxPace { get; set; }
    
    [Column("average_pace")]
    public double AveragePace { get; set; }
    
    [Column("min_speed")]
    public double MinSpeed { get; set; }
    
    [Column("max_speed")]
    public double MaxSpeed { get; set; }
    
    [Column("average_speed")]
    public double AverageSpeed { get; set; }
}