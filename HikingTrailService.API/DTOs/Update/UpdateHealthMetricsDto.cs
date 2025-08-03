using System.ComponentModel.DataAnnotations;
using Common.API.DataAnnotations;

namespace HikingTrailService.DTOs.Update;

public record UpdateHealthMetricsDto
{
    [GuidValidator(ErrorMessage = "Hiking Trail Code must be a valid GUID")]
    public Guid? HikingTrailCode { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "Min heart rate minimum value must be 0")]
    public int? MinHeartRate { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "Max heart rate minimum value must be 0")]
    public int? MaxHeartRate { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "Average heart rate minimum value must be 0")]
    public int? AverageHeartRate { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "Calories burned minimum value must be 0")]
    public int? CaloriesBurned { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "Steps minimum value must be 0")]
    public int? Steps { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "Elevation gain minimum value must be 0")]
    public int? ElevationGain { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "Min pace minium value must be 0")]
    public double? MinPace { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "Max pace minium value must be 0")]
    public double? MaxPace { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "Average pace minium value must be 0")]
    public double? AveragePace { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "Min speed minium value must be 0")]
    public double? MinSpeed { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "Max speed minium value must be 0")]
    public double? MaxSpeed { get; set; }
    
    [Range(0, Double.MaxValue, ErrorMessage = "Average speed minium value must be 0")]
    public double? AverageSpeed { get; set; }
}