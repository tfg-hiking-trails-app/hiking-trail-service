namespace HikingTrailService.DTOs;

public record ActivityFileUploadDto
{
    public IFormFile? ActivityFile { get; set; }
}