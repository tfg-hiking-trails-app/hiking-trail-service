using Common.API.DTOs.Create;

namespace HikingTrailService.DTOs.Create;

public record CreateTrailTypeDto : CreateBaseDto
{
    public required string Trail { get; set; }
}