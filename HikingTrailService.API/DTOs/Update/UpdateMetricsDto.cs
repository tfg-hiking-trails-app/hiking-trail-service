using System.ComponentModel.DataAnnotations;
using Common.API.DataAnnotations;
using Common.API.DTOs.Update;

namespace HikingTrailService.DTOs.Update;

public record UpdateMetricsDto : UpdateBaseDto
{
    [GuidValidator(ErrorMessage = "DifficultyLevelCode must be a valid GUID")]
    public Guid? HikingTrailCode { get; set; }
    
    [Required(ErrorMessage = "Distance is required")]
    [Range(0, Int32.MaxValue, ErrorMessage = "Distance minium value must be 0")]
    public required int Distance { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "Duration minium value must be 0")]
    public double? Duration { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "Steps minium value must be 0")]
    public int? Steps { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "Calories minium value must be 0")]
    public int? Calories { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "AveragePace minium value must be 0")]
    public double? AveragePace { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "MaxPace minium value must be 0")]
    public double? MaxPace { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "ElevationGain minium value must be 0")]
    public double? ElevationGain { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "ElevationLoss minium value must be 0")]
    public double? ElevationLoss { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "AverageSpeed minium value must be 0")]
    public double? AverageSpeed { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "MaxSpeed minium value must be 0")]
    public double? MaxSpeed { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "AverageHeartRate minium value must be 0")]
    public int? AverageHeartRate { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "MaxHeartRate minium value must be 0")]
    public int? MaxHeartRate { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "MinHeartRate minium value must be 0")]
    public int? MinHeartRate { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "AverageCadence minium value must be 0")]
    public double? AverageCadence { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "MaxCadence minium value must be 0")]
    public double? MaxCadence { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "MaxAltitude minium value must be 0")]
    public double? MaxAltitude { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "MinAltitude minium value must be 0")]
    public double? MinAltitude { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "TotalTrainingEffect minium value must be 0")]
    public double? TotalTrainingEffect { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "TrainingStressScore minium value must be 0")]
    public double? TrainingStressScore { get; set; }
}