namespace HikingTrailService.Application.DTOs;

public class FitDataResponseDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Distance { get; set; }
    public int LowestElevation { get; set; }
    public int HighestElevation { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? Ubication { get; set; }
    public int MinHeartRate { get; set; }
    public int MaxHeartRate { get; set; }
    public int AverageHeartRate { get; set; }
    public int CaloriesBurned { get; set; }
    public int Steps { get; set; }
    public int ElevationGain { get; set; }
    public double MinPace { get; set; }
    public double MaxPace { get; set; }
    public double AveragePace { get; set; }
    public double MinSpeed { get; set; }
    public double MaxSpeed { get; set; }
    public double AverageSpeed { get; set; }
}