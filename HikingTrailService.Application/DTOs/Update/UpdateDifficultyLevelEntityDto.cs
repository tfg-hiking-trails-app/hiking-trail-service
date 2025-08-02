namespace HikingTrailService.Application.DTOs.Update;

public record UpdateDifficultyLevelEntityDto
{
    public Guid Code { get; set; }
    public required string DifficultyLevelValue { get; set; }
}