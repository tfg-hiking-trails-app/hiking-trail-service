using System.ComponentModel.DataAnnotations;
using Common.API.DataAnnotations;
using Common.API.DTOs.Create;

namespace HikingTrailService.DTOs.Create;

public record CreateHikingTrailDto : CreateBaseDto
{
    [GuidValidator(ErrorMessage = "DifficultyLevelCode must be a valid GUID")]
    public Guid? DifficultyLevelCode { get; set; }
    
    [GuidValidator(ErrorMessage = "TerrainTypeCode must be a valid GUID")]
    public Guid? TerrainTypeCode { get; set; }
    
    [GuidValidator(ErrorMessage = "TrailTypeCode must be a valid GUID")]
    public Guid? TrailTypeCode { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public bool PetFriendly { get; set; }
    
    [Required(ErrorMessage = "Start time is required")]
    public required DateTime StartTime { get; set; }
    
    [Required(ErrorMessage = "End time is required")]
    public required DateTime EndTime { get; set; }
    
    [Required(ErrorMessage = "Ubication latitude is required")]
    public required double UbicationLatitude { get; set; }
    
    [Required(ErrorMessage = "Ubication longitude is required")]
    public required double UbicationLongitude { get; set; }
    
    public bool Deleted { get; set; }
    
    public bool GeneratedByFitFile { get; set; }
}