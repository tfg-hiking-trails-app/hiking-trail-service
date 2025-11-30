namespace HikingTrailService.Application.DTOs.Update;

public record UpdateMetricsScoreEntityDto
{
    public required Guid AccountCode { get; set; }
    public byte Distance { get; set; } = 0;
    public byte Duration { get; set; } = 0;
    public byte Steps { get; set; } = 0;
    public byte Calories { get; set; } = 0;
    public byte Pace { get; set; } = 0;
    public byte Elevation { get; set; } = 0;
    public byte HeartRate { get; set; } = 0;
    public byte Speed { get; set; } = 0;
}