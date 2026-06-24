namespace HikingTrailService.Domain.Explore;

public enum ExploreSortMode
{
    /// <summary>Newest first (by StartTime, then EndTime).</summary>
    Newest,

    /// <summary>Most voted first (by number of prestiges).</summary>
    MostPrestigious,

    /// <summary>Longest first (by total distance).</summary>
    Longest
}
