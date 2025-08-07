using Common.API.DTOs;

namespace HikingTrailService.DTOs;

public record TerrainTypeDto : BaseDto
{
    public required string Terrain { get; set; }
}