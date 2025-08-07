using Common.Application.DTOs.Create;

namespace HikingTrailService.Application.DTOs.Create;

public record CreateTrailTypeEntityDto : CreateBaseEntityDto
{
    public required string Trail { get; set; }
}