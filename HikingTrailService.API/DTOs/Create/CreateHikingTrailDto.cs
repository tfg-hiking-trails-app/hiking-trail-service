using System.ComponentModel.DataAnnotations;
using Common.API.DataAnnotations;

namespace HikingTrailService.DTOs.Create;

public record CreateHikingTrailDto
{
    [GuidValidator(ErrorMessage = "DifficultyLevelCode must be a valid GUID")]
    public Guid? DifficultyLevelCode { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "Distance is required")]
    [Range(0, Double.MaxValue, ErrorMessage = "Distance minium value must be 0")]
    public required int Distance { get; set; }
    
    public bool PetFriendly { get; set; }
    
    [Required(ErrorMessage = "Start time is required")]
    public required DateTime StartTime { get; set; }
    
    [Required(ErrorMessage = "End time is required")]
    public required DateTime EndTime { get; set; }
    
    [Required(ErrorMessage = "Duration is required")]
    public required double Duration { get; set; }
    
    [Required(ErrorMessage = "Ubication latitude is required")]
    public required double UbicationLatitude { get; set; }
    
    [Required(ErrorMessage = "Ubication longitude is required")]
    public required double UbicationLongitude { get; set; }
}