using Common.Application.DTOs.Filter;

namespace HikingTrailService.Application.DTOs.Filter;

public record HikingTrailFilterEntityDto
{
    public required List<Guid> AccountCodes { get; set; }
    public required FilterEntityDto Filter { get; set; }
}