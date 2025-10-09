using Common.API.DTOs.Update;

namespace HikingTrailService.DTOs.Update;

public record UpdateImagesDto : UpdateBaseDto
{
    public required Guid? HikingTrailCode { get; set; }
    public required string ImageUrl { get; set; }
    public int OrderIndex { get; set; }
}