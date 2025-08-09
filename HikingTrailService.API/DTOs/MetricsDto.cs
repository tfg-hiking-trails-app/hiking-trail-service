using Common.API.DTOs;

namespace HikingTrailService.DTOs;

public record MetricsDto : BaseDto
{
    public required int Distance { get; set; }
    public double? Duration { get; set; }
    public int? Steps { get; set; }
    public int? Calories { get; set; }
    public double? AveragePace { get; set; }
    public double? MaxPace { get; set; }
    public double? ElevationGain { get; set; }
    public double? ElevationLoss { get; set; }
    public double? AverageSpeed { get; set; }
    public double? MaxSpeed { get; set; }
    public int? AverageHeartRate { get; set; }
    public int? MaxHeartRate { get; set; }
    public int? MinHeartRate { get; set; }
    public double? AverageCadence { get; set; }
    public double? MaxCadence { get; set; }
    public double? MaxAltitude { get; set; }
    public double? MinAltitude { get; set; }
    public double? TotalTrainingEffect { get; set; }
    public double? TrainingStressScore { get; set; }
}