using Common.API.DTOs;

namespace HikingTrailService.DTOs;

public record RecommenderDto : BaseDto
{
    public required Guid AccountCode { get; set; }
    public int Kilometers { get; init; } = 10;
    public required double LocationLatitude { get; set; }
    public required double LocationLongitude { get; set; }
}