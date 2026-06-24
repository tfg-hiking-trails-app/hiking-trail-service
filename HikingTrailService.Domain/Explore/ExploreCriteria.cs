namespace HikingTrailService.Domain.Explore;

public record ExploreCriteria
{
    public bool? PetFriendly { get; init; }
    public Guid? DifficultyLevelCode { get; init; }
    public Guid? TerrainTypeCode { get; init; }
    public Guid? TrailTypeCode { get; init; }
    public ExploreSortMode SortMode { get; init; } = ExploreSortMode.Newest;
}
