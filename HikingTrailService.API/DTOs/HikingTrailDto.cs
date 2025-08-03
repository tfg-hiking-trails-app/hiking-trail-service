namespace HikingTrailService.DTOs;

public class HikingTrailDto
{
    public Guid Code { get; set; }
    public required DifficultyLevelDto DifficultyLevel { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required double Distance { get; set; }
    public int? LowestElevation { get; set; }
    public int? HighestElevation { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public required string Ubication { get; set; }
    public bool? PetFriendly { get; set; }
}