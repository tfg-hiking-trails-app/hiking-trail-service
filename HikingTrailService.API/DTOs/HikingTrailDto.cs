using Common.API.DTOs;

namespace HikingTrailService.DTOs;

public record HikingTrailDto : BaseDto
{
    public Guid AccountCode { get; set; }
    public DifficultyLevelDto? DifficultyLevel { get; set; }
    public TerrainTypeDto? TerrainType { get; set; }
    public TrailTypeDto? TrailType { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool PetFriendly { get; set; }
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }
    public required double LocationLatitude { get; set; }
    public required double LocationLongitude { get; set; }
    public bool GeneratedByFitFile { get; set; }
    
    public ICollection<MetricsDto> Metrics { get; init; } = new List<MetricsDto>();
    public ICollection<ImagesDto> Images  { get; init; } = new List<ImagesDto>();
    public ICollection<LocationDto> Locations { get; init; } = new List<LocationDto>();
    public ICollection<PrestigeDto> Prestiges { get; init; } = new List<PrestigeDto>();
    public ICollection<CommentDto> Comments { get; init; } = new List<CommentDto>();
}