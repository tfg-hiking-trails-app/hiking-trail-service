using System.ComponentModel.DataAnnotations;
using Common.API.DataAnnotations;

namespace HikingTrailService.DTOs.Update;

public record UpdateDifficultyLevelDto
{
    [Required(ErrorMessage = "Code is required")]
    [GuidValidator(ErrorMessage = "Code must be a valid GUID")]
    public Guid Code { get; init; }
    
    [Required(ErrorMessage = "Difficulty level is required")]
    public required string DifficultyLevelValue { get; set; }
}