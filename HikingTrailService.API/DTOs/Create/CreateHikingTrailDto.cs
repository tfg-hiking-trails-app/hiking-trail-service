using System.ComponentModel.DataAnnotations;
using Common.API.DataAnnotations;

namespace HikingTrailService.DTOs.Create;

public record CreateHikingTrailDto
{
    [Required(ErrorMessage = "DifficultyLevelCode is required")]
    [GuidValidator(ErrorMessage = "DifficultyLevelCode must be a valid GUID")]
    public Guid DifficultyLevelCode { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "Distance is required")]
    [Range(0, Double.MaxValue, ErrorMessage = "Distance minium value must be 0")]
    public required double Distance { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "Lowest elevation minimum value must be 0")]
    public int? LowestElevation { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "Highest elevation minimum value must be 0")]
    public int? HighestElevation { get; set; }
    
    public DateTime? StartTime { get; set; }
    
    public DateTime? EndTime { get; set; }
    
    [Required(ErrorMessage = "Ubication is required")]
    public required string Ubication { get; set; }
    
    public bool? PetFriendly { get; set; }
}