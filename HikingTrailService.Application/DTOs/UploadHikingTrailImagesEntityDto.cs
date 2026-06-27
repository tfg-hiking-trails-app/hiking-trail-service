using Common.Application;

namespace HikingTrailService.Application.DTOs;

public record UploadHikingTrailImagesEntityDto
{
    public List<FileEntityDto> Images { get; set; } = new List<FileEntityDto>();
}
