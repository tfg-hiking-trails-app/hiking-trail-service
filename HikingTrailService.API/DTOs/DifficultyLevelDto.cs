namespace HikingTrailService.DTOs;

public class DifficultyLevelDto
{
    public Guid Code { get; set; }
    public required string DifficultyLevelValue { get; set; }
}