using System.ComponentModel.DataAnnotations;
using Common.API.DTOs.Update;

namespace HikingTrailService.DTOs.Update;

public record UpdateDifficultyLevelDto : UpdateBaseDto
{
    [Required(ErrorMessage = "Difficulty level is required")]
    public required string DifficultyLevelValue { get; set; }
}