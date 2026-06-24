using Common.Application.DTOs.Filter;

namespace HikingTrailService.Application.DTOs.Filter;

public record ExploreFilterEntityDto
{
    public bool? PetFriendly { get; set; }
    public Guid? DifficultyLevelCode { get; set; }
    public Guid? TerrainTypeCode { get; set; }
    public Guid? TrailTypeCode { get; set; }
    public string? SortMode { get; set; }
    public required FilterEntityDto Filter { get; set; }
}
