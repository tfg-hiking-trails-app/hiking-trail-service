using Common.Application.DTOs;

namespace HikingTrailService.Application.DTOs;

public record PrestigeEntityDto : BaseEntityDto
{
    public Guid ReceiverAccountCode { get; set; }
    public Guid GiverAccountCode { get; set; }
}