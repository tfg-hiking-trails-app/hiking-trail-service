namespace HikingTrailService.Application.DTOs.Create;

public record CreateHikingTrailEntityDto
{
    public required Guid DifficultyLevelCode { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required double Distance { get; set; }
    public int? LowestElevation { get; set; }
    public int? HighestElevation { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public required string Ubication { get; set; }
    public bool PetFriendly { get; set; }
}