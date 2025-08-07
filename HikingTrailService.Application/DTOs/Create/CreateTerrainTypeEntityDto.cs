using Common.Application.DTOs.Create;

namespace HikingTrailService.Application.DTOs.Create;

public record CreateTerrainTypeEntityDto : CreateBaseEntityDto
{
    public required string Terrain { get; set; }
}