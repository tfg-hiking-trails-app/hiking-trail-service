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
    public required double UbicationLatitude { get; set; }
    public required double UbicationLongitude { get; set; }
    public bool Deleted { get; set; }
    public bool GeneratedByFitFile { get; set; }
    
    public ICollection<MetricsEntityDto> Metrics { get; init; } = new List<MetricsEntityDto>();
    public ICollection<ImagesEntityDto> Images  { get; init; } = new List<ImagesEntityDto>();
}