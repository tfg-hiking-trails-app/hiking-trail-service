using Common.API.DTOs;

namespace HikingTrailService.DTOs;

public record CollectionDto : BaseDto
{
    public Guid AccountCode { get; set; }
    public required string Name { get; set; }
    public bool IsDefault { get; set; }
    public int TrailCount { get; set; }
}
