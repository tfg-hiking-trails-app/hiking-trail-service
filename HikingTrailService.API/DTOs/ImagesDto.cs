using Common.API.DTOs;

namespace HikingTrailService.DTOs;

public record ImagesDto : BaseDto
{
    public HikingTrailDto? HikingTrail { get; set; }
    public required string ImageUrl { get; set; }
}