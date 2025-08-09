using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace HikingTrailService.Domain.Entities;

[Table("Metrics")]
public class Metrics : BaseEntity
{
    [Required]
    [Column("hiking_trail_id")]
    public int HikingTrailId { get; set; }
    
    [ForeignKey("HikingTrailId")]
    public required HikingTrail HikingTrail { get; set; }
    
    [Required]
    [Column("distance")]
    public required int Distance { get; set; }
    
    [Column("duration")]
    public double? Duration { get; set; }
    
    [Column("steps")]
    public int? Steps { get; set; }
    
    [Column("calories")]
    public int? Calories { get; set; }
    
    [Column("average_pace")]
    public double? AveragePace { get; set; }
    
    [Column("max_pace")]
    public double? MaxPace { get; set; }

    [Column("elevation_gain")]
    public double? ElevationGain { get; set; }

    [Column("elevation_loss")]
    public double? ElevationLoss { get; set; }

    [Column("average_speed")]
    public double? AverageSpeed { get; set; }

    [Column("max_speed")]
    public double? MaxSpeed { get; set; }

    [Column("average_heart_rate")]
    public int? AverageHeartRate { get; set; }

    [Column("max_heart_rate")]
    public int? MaxHeartRate { get; set; }

    [Column("min_heart_rate")]
    public int? MinHeartRate { get; set; }

    [Column("average_cadence")]
    public double? AverageCadence { get; set; }

    [Column("max_cadence")]
    public double? MaxCadence { get; set; }

    [Column("max_altitude")]
    public double? MaxAltitude { get; set; }

    [Column("min_altitude")]
    public double? MinAltitude { get; set; }

    [Column("total_training_effect")]
    public double? TotalTrainingEffect { get; set; }

    [Column("training_stress_score")]
    public double? TrainingStressScore { get; set; }
}