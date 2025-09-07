using Common.Application;

namespace HikingTrailService.Application.DTOs;

public record ActivityFileEntityDto : FileEntityDto
{
    public required Guid UserCode { get; set; }
}