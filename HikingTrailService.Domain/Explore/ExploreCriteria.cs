namespace HikingTrailService.Domain.Explore;

public record ExploreCriteria
{
    public bool? PetFriendly { get; init; }
    public Guid? DifficultyLevelCode { get; init; }
    public Guid? TerrainTypeCode { get; init; }
    public Guid? TrailTypeCode { get; init; }
    public int? MaxDistance { get; init; }
    public int? MaxElevationGain { get; init; }
    public int? MaxAltitude { get; init; }
    public DateTime? StartTimeFrom { get; init; }
    public ExploreSortMode SortMode { get; init; } = ExploreSortMode.Newest;
}
