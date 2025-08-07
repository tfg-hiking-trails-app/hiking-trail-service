using Common.Application.DTOs;

namespace HikingTrailService.Application.DTOs;

public record TrailTypeEntityDto : BaseEntityDto
{
    public required string Trail { get; set; }
}