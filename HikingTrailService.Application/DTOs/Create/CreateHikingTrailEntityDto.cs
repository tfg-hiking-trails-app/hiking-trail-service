using Common.Application;
using Common.Application.DTOs.Create;

namespace HikingTrailService.Application.DTOs.Create;

public record CreateHikingTrailEntityDto : CreateBaseEntityDto
{
    public required Guid AccountCode { get; set; }
    public Guid? DifficultyLevelCode { get; set; }
    public Guid? TerrainTypeCode { get; set; }
    public Guid? TrailTypeCode { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool PetFriendly { get; set; }
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }
    public double? LocationLatitude { get; set; }
    public double? LocationLongitude { get; set; }
    public List<FileEntityDto> Images { get; set; } = new List<FileEntityDto>();
    public bool Deleted { get; set; }
    public bool GeneratedByFitFile { get; set; }
    public CreateMetricsEntityDto? Metrics { get; set; }
}