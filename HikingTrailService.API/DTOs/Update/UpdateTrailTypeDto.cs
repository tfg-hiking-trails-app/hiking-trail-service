using Common.API.DTOs.Update;

namespace HikingTrailService.DTOs.Update;

public record UpdateTrailTypeDto : UpdateBaseDto
{
    public required string Trail { get; set; }
}