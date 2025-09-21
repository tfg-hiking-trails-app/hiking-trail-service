using Common.Application.DTOs.Create;

namespace HikingTrailService.DTOs.Create;

public record CreateCommentDto : CreateBaseEntityDto
{
    public Guid? HikingTrailCode { get; set; }
    public Guid AccountCode { get; set; }
    public required string CommentText { get; set; }
}