using Common.API.DTOs.Filter;

namespace HikingTrailService.DTOs.Filter;

public record ExploreFilterDto
{
    public bool? PetFriendly { get; set; }
    public Guid? DifficultyLevelCode { get; set; }
    public Guid? TerrainTypeCode { get; set; }
    public Guid? TrailTypeCode { get; set; }
    public int? MaxDistance { get; set; }
    public int? MaxElevationGain { get; set; }
    public int? MaxAltitude { get; set; }
    public string? DateRange { get; set; }
    public string? SortMode { get; set; }

    public FilterDto Filter { get; set; } = new FilterDto();
}
