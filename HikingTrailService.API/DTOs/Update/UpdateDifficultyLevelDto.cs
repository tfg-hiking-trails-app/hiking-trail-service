using System.ComponentModel.DataAnnotations;

namespace HikingTrailService.DTOs.Update;

public record UpdateDifficultyLevelDto
{
    [Required(ErrorMessage = "Difficulty level is required")]
    public required string DifficultyLevelValue { get; set; }
}