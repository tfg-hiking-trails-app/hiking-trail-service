using System.ComponentModel.DataAnnotations;
using Common.API.DTOs.Create;

namespace HikingTrailService.DTOs.Create;

public record CreateCollectionDto : CreateBaseDto
{
    [Required(ErrorMessage = "The collection name is required")]
    [MaxLength(100, ErrorMessage = "The collection name is too long")]
    public required string Name { get; set; }
}
