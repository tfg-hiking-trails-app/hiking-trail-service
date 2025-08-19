using Common.API.DTOs.Filter;

namespace HikingTrailService.DTOs.Filter;

public record HikingTrailFilterDto
{
    public List<Guid> AccountCodes { get; set; } = new List<Guid>();
    public FilterDto Filter { get; set; } = new FilterDto();
}