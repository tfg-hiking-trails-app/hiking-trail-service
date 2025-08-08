using Common.API.DTOs;

namespace HikingTrailService.DTOs;

public record HikingTrailDto : BaseDto
{
    public Guid UserCode { get; set; }
    public DifficultyLevelDto? DifficultyLevel { get; set; }
    public TerrainTypeDto? TerrainType { get; set; }
    public TrailTypeDto? TrailType { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool PetFriendly { get; set; }
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }
    public required double UbicationLatitude { get; set; }
    public required double UbicationLongitude { get; set; }
    public bool Deleted { get; set; }
    public bool GeneratedByFitFile { get; set; }
}