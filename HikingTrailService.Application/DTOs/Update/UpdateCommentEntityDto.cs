namespace HikingTrailService.Application.DTOs.Update;

public record UpdateCommentEntityDto
{
    public Guid? HikingTrailCode { get; set; }
    public Guid AccountCode { get; set; }
    public required string CommentText { get; set; }
}