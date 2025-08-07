using Common.API.DTOs.Create;

namespace HikingTrailService.DTOs.Create;

public record CreateTerrainTypeDto : CreateBaseDto
{
    public required string Terrain { get; set; }
}