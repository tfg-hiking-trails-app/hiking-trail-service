namespace HikingTrailService.Domain.Recommender;

public record RecommenderData
{
    public int Kilometers { get; init; } = 10;
    public required double LocationLatitude { get; set; }
    public required double LocationLongitude { get; set; }
}