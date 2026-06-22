using System.ComponentModel.DataAnnotations;
using Common.API.DataAnnotations;

namespace HikingTrailService.DTOs.Create;

public record AddTrailToCollectionDto
{
    [Required(ErrorMessage = "Hiking Trail Code is required")]
    [GuidValidator(ErrorMessage = "Hiking Trail Code is invalid")]
    public Guid? HikingTrailCode { get; set; }
}
