using Common.Application.DTOs;

namespace HikingTrailService.Application.DTOs;

public record HikingTrailEntityDto : BaseEntityDto
{
    public Guid AccountCode { get; set; }
    public DifficultyLevelEntityDto? DifficultyLevel { get; set; }
    public TerrainTypeEntityDto? TerrainType { get; set; }
    public TrailTypeEntityDto? TrailType { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool PetFriendly { get; set; }
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }
    public required double LocationLatitude { get; set; }
    public required double LocationLongitude { get; set; }
    public bool Deleted { get; set; }
    public bool GeneratedByFitFile { get; set; }
    
    public ICollection<MetricsEntityDto> Metrics { get; init; } = new List<MetricsEntityDto>();
    public ICollection<ImagesEntityDto> Images  { get; init; } = new List<ImagesEntityDto>();
    public ICollection<LocationEntityDto> Locations { get; init; } = new List<LocationEntityDto>();
    public ICollection<PrestigeEntityDto> Prestiges { get; init; } = new List<PrestigeEntityDto>();
    public ICollection<CommentEntityDto> Comments { get; init; } = new List<CommentEntityDto>();
}