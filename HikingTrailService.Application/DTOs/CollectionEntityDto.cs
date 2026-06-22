using Common.Application.DTOs;

namespace HikingTrailService.Application.DTOs;

public record CollectionEntityDto : BaseEntityDto
{
    public Guid AccountCode { get; set; }
    public required string Name { get; set; }
    public bool IsDefault { get; set; }
    public int TrailCount { get; set; }
}
