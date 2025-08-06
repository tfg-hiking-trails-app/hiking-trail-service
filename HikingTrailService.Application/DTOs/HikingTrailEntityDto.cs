namespace HikingTrailService.Application.DTOs;

public record HikingTrailEntityDto
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    public DifficultyLevelEntityDto? DifficultyLevel { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required int Distance { get; set; }
    public bool PetFriendly { get; set; }
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }
    public required double Duration { get; set; }
    public required double UbicationLatitude { get; set; }
    public required double UbicationLongitude { get; set; }
}