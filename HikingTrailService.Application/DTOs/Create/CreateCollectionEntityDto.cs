using Common.Application.DTOs.Create;

namespace HikingTrailService.Application.DTOs.Create;

public record CreateCollectionEntityDto : CreateBaseEntityDto
{
    public Guid AccountCode { get; set; }
    public required string Name { get; set; }
}
