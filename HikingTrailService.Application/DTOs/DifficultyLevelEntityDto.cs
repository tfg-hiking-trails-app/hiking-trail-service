namespace HikingTrailService.Application.DTOs;

public record DifficultyLevelEntityDto
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    public string? DifficultyLevelValue { get; set; }
}