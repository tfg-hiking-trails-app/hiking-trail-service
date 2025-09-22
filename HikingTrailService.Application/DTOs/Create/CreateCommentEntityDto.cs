using Common.Application.DTOs.Create;

namespace HikingTrailService.Application.DTOs.Create;

public record CreateCommentEntityDto : CreateBaseEntityDto
{
    public required Guid HikingTrailCode { get; set; }
    public required Guid AccountCode { get; set; }
    public required string CommentText { get; set; }
}