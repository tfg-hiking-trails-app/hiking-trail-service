using Common.API.DTOs.Update;

namespace HikingTrailService.DTOs.Update;

public record UpdateCommentDto : UpdateBaseDto
{
    public Guid AccountCode { get; set; }
    public required string CommentText { get; set; }
}