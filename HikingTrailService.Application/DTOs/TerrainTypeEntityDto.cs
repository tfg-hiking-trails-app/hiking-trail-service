using Common.Application.DTOs;

namespace HikingTrailService.Application.DTOs;

public record TerrainTypeEntityDto : BaseEntityDto
{
    public required string Terrain { get; set; }
}