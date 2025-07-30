namespace HikingTrailService.Application.DTOs;

public class HikingTrailEntityDto
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    public DifficultyLevelEntityDto? DifficultyLevel { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Distance { get; set; }
    public int LowestElevation { get; set; }
    public int HighestElevation { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? Ubication { get; set; }
    public bool PetFriendly { get; set; }
}