using Common.API.DTOs;

namespace HikingTrailService.DTOs;

public record DifficultyLevelDto : BaseDto
{
    public required string DifficultyLevelValue { get; set; }
}