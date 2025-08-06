using System.ComponentModel.DataAnnotations;

namespace HikingTrailService.DTOs.Update;

public record UpdateHikingTrailDto
{
    public Guid? DifficultyLevelCode { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    [Range(0, Double.MaxValue)]
    public double? Distance { get; set; }

    public bool? PetFriendly { get; set; }
    
    public DateTime? StartTime { get; set; }
    
    public DateTime? EndTime { get; set; }
    
    public double? Duration { get; set; }
    
    public double? UbicationLatitude { get; set; }
    
    public double? UbicationLongitude { get; set; }
}