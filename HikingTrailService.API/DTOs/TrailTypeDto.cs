using Common.API.DTOs;

namespace HikingTrailService.DTOs;

public record TrailTypeDto : BaseDto
{
    public required string Trail { get; set; }
}