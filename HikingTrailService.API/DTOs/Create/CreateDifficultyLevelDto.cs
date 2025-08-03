using System.ComponentModel.DataAnnotations;

namespace HikingTrailService.DTOs.Create;

public record CreateDifficultyLevelDto
{
    [Required(ErrorMessage = "Difficulty level is required")]
    public required string DifficultyLevelValue { get; set; }
}