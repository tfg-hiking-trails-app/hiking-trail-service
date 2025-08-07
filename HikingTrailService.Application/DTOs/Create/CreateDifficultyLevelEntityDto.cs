using Common.Application.DTOs.Create;

namespace HikingTrailService.Application.DTOs.Create;

public record CreateDifficultyLevelEntityDto : CreateBaseEntityDto
{
    public required string DifficultyLevelValue { get; set; }
}