using Common.API.DTOs;

namespace HikingTrailService.DTOs;

public record PrestigeDto : BaseDto
{
    public Guid ReceiverAccountCode { get; set; }
    public Guid GiverAccountCode { get; set; }
}