using Common.API.DataAnnotations;
using Common.API.DTOs.Update;

namespace HikingTrailService.DTOs.Update;

public record UpdateHikingTrailDto : UpdateBaseDto
{
    [GuidValidator(ErrorMessage = "UserCode must be a valid GUID")]
    public Guid? UserCode { get; set; }
    
    [GuidValidator(ErrorMessage = "DifficultyLevelCode must be a valid GUID")]
    public Guid? DifficultyLevelCode { get; set; }
    
    [GuidValidator(ErrorMessage = "TerrainTypeCode must be a valid GUID")]
    public Guid? TerrainTypeCode { get; set; }
    
    [GuidValidator(ErrorMessage = "TrailTypeCode must be a valid GUID")]
    public Guid? TrailTypeCode { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }

    public bool? PetFriendly { get; set; }
    
    public DateTime? StartTime { get; set; }
    
    public DateTime? EndTime { get; set; }
    
    public double? UbicationLatitude { get; set; }
    
    public double? UbicationLongitude { get; set; }
    
    public bool Deleted { get; set; }
    public bool GeneratedByFitFile { get; set; }
}