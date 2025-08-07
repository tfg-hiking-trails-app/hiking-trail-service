using Common.Application.DTOs;

namespace HikingTrailService.Application.DTOs;

public record DifficultyLevelEntityDto : BaseEntityDto
{
    public string? DifficultyLevelValue { get; set; }
}