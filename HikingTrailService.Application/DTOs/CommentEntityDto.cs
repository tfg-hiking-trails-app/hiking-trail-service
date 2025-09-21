using Common.Application.DTOs;

namespace HikingTrailService.Application.DTOs;

public record CommentEntityDto : BaseEntityDto
{
    public Guid AccountCode { get; set; }
    public required string CommentText { get; set; }
}