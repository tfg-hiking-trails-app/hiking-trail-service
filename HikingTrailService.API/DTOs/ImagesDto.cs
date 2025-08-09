using Common.API.DTOs;

namespace HikingTrailService.DTOs;

public record ImagesDto : BaseDto
{
    public required string ImageUrl { get; set; }
}