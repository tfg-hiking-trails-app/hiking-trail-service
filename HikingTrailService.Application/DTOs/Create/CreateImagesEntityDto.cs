using Common.Application.DTOs.Create;

namespace HikingTrailService.Application.DTOs.Create;

public record CreateImagesEntityDto : CreateBaseEntityDto
{
    public Guid? HikingTrailCode { get; set; }
    public required string ImageUrl { get; set; }
}