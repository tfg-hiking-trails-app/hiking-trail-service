using System.ComponentModel.DataAnnotations;

namespace HikingTrailService.DTOs.Update;

public record UpdateHikingTrailDto
{
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    [Range(0, Double.MaxValue)]
    public double? Distance { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "Lowest elevation minimum value must be 0")]
    public int? LowestElevation { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "Highest elevation minimum value must be 0")]
    public int? HighestElevation { get; set; }
    
    public DateTime? StartTime { get; set; }
    
    public DateTime? EndTime { get; set; }
    
    public string? Ubication { get; set; }
    
    public bool? PetFriendly { get; set; }
}