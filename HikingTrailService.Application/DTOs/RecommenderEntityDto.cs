using Common.Application.DTOs;

namespace HikingTrailService.Application.DTOs;

public record RecommenderEntityDto : BaseEntityDto
{
    public required Guid AccountCode { get; set; }
    public int Kilometers { get; init; } = 10;
    public required double LocationLatitude { get; set; }
    public required double LocationLongitude { get; set; }
}