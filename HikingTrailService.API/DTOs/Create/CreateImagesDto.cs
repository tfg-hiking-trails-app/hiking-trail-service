using Common.API.DTOs.Create;

namespace HikingTrailService.DTOs.Create;

public record CreateImagesDto : CreateBaseDto
{
    public required Guid HikingTrailCode { get; set; }
    public required string ImageUrl { get; set; }
}