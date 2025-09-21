using Common.Application.DTOs.Create;

namespace HikingTrailService.Application.DTOs.Create;

public record CreateCommentEntityDto : CreateBaseEntityDto
{
    public Guid? HikingTrailCode { get; set; }
    public Guid AccountCode { get; set; }
    public required string CommentText { get; set; }
}