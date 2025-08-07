using Common.API.DTOs.Update;

namespace HikingTrailService.DTOs.Update;

public record UpdateTerrainTypeDto : UpdateBaseDto
{
    public required string Terrain { get; set; }
}