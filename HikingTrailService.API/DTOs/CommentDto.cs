using Common.API.DTOs;

namespace HikingTrailService.DTOs;

public record CommentDto : BaseDto
{
    public Guid AccountCode { get; set; }
    public required string CommentText { get; set; }
}