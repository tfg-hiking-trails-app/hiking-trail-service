namespace HikingTrailService.Application.DTOs.Create;

public record CreateDifficultyLevelEntityDto
{
    public required string DifficultyLevelValue { get; set; }
}