namespace HikingTrailService.Application.DTOs.Create;

public record CreateHealthMetricsEntityDto
{
    public required Guid HikingTrailCode { get; set; }
    public int? MinHeartRate { get; set; }
    public int? MaxHeartRate { get; set; }
    public int? AverageHeartRate { get; set; }
    public int? CaloriesBurned { get; set; }
    public int? Steps { get; set; }
    public int? ElevationGain { get; set; }
    public double? MinPace { get; set; }
    public double? MaxPace { get; set; }
    public double? AveragePace { get; set; }
    public double? MinSpeed { get; set; }
    public double? MaxSpeed { get; set; }
    public double? AverageSpeed { get; set; }
}