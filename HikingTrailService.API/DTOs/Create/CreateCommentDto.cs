using System.ComponentModel.DataAnnotations;
using Common.Application.DTOs.Create;

namespace HikingTrailService.DTOs.Create;

public record CreateCommentDto : CreateBaseEntityDto
{
    [Required(ErrorMessage = "Hiking Trail Code is required")]
    public required Guid HikingTrailCode { get; set; }
    
    [Required(ErrorMessage = "Account Code is required")]
    public required Guid AccountCode { get; set; }
    
    [Required(ErrorMessage = "Comment text is required")]
    [MinLength(1, ErrorMessage = "Comment text must be at least 1 characters")]
    public required string CommentText { get; set; }
}