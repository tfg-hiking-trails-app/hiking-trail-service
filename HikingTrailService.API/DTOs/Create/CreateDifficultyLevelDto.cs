using System.ComponentModel.DataAnnotations;
using Common.API.DTOs.Create;

namespace HikingTrailService.DTOs.Create;

public record CreateDifficultyLevelDto : CreateBaseDto
{
    [Required(ErrorMessage = "Difficulty level is required")]
    public required string DifficultyLevelValue { get; set; }
}