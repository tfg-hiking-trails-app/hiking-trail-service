namespace HikingTrailService.DTOs;

public record UploadHikingTrailImagesDto
{
    public List<IFormFile> Images { get; set; } = new List<IFormFile>();
}
