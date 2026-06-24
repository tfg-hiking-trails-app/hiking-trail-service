using System.ComponentModel.DataAnnotations;
using Common.API.DTOs;

namespace HikingTrailService.DTOs;

public record RecommenderDto : BaseDto
{
    public required Guid AccountCode { get; set; }

    [Range(1, 50, ErrorMessage = "Kilometers must be between 1 and 50.")]
    public int Kilometers { get; init; } = 10;

    [Range(-90, 90, ErrorMessage = "LocationLatitude must be between -90 and 90.")]
    public required double LocationLatitude { get; set; }

    [Range(-180, 180, ErrorMessage = "LocationLongitude must be between -180 and 180.")]
    public required double LocationLongitude { get; set; }
}