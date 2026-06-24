using Common.API.DTOs.Filter;

namespace HikingTrailService.DTOs.Filter;

public record ExploreFilterDto
{
    public bool? PetFriendly { get; set; }
    public Guid? DifficultyLevelCode { get; set; }
    public Guid? TerrainTypeCode { get; set; }
    public Guid? TrailTypeCode { get; set; }

    /// <summary>"newest" (default), "most-prestigious" or "longest".</summary>
    public string? SortMode { get; set; }

    public FilterDto Filter { get; set; } = new FilterDto();
}
