using Common.Application.DTOs;

namespace HikingTrailService.Application.DTOs;

public record ImagesEntityDto : BaseEntityDto
{
    public HikingTrailEntityDto? HikingTrail { get; set; }
    public required string ImageUrl { get; set; }
}