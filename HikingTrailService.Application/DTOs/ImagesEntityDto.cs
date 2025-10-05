using Common.Application.DTOs;

namespace HikingTrailService.Application.DTOs;

public record ImagesEntityDto : BaseEntityDto
{
    public required string ImageUrl { get; set; }
    public bool Deleted { get; set; }
}