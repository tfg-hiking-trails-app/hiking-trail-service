using System.ComponentModel.DataAnnotations;
using Common.API.DataAnnotations;
using Common.API.DTOs.Update;

namespace HikingTrailService.DTOs.Update;

public record UpdateMetricsScoreDto : UpdateBaseDto
{
    [Required]
    [GuidValidator(ErrorMessage = "AccountCode must be a valid GUID")]
    public required Guid AccountCode { get; set; }
    
    [Range(0, 10, ErrorMessage = "Distance range must be between 0 and 10")]
    public byte Distance { get; set; } = 0;
    
    [Range(0, 10, ErrorMessage = "Duration range must be between 0 and 10")]
    public byte Duration { get; set; } = 0;
    
    [Range(0, 10, ErrorMessage = "Steps range must be between 0 and 10")]
    public byte Steps { get; set; } = 0;
    
    [Range(0, 10, ErrorMessage = "Calories range must be between 0 and 10")]
    public byte Calories { get; set; } = 0;
    
    [Range(0, 10, ErrorMessage = "Pace range must be between 0 and 10")]
    public byte Pace { get; set; } = 0;
    
    [Range(0, 10, ErrorMessage = "Elevation range must be between 0 and 10")]
    public byte Elevation { get; set; } = 0;
    
    [Range(0, 10, ErrorMessage = "HeartRate range must be between 0 and 10")]
    public byte HeartRate { get; set; } = 0;
    
    [Range(0, 10, ErrorMessage = "Speed range must be between 0 and 10")]
    public byte Speed { get; set; } = 0;
}