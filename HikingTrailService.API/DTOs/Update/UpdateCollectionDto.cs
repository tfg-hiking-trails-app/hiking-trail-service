using System.ComponentModel.DataAnnotations;
using Common.API.DTOs.Update;

namespace HikingTrailService.DTOs.Update;

public record UpdateCollectionDto : UpdateBaseDto
{
    [Required(ErrorMessage = "The collection name is required")]
    [MaxLength(100, ErrorMessage = "The collection name is too long")]
    public required string Name { get; set; }
}
