using Common.API.DTOs.Update;

namespace HikingTrailService.DTOs.Update;

public record UpdatePrestigeDto : UpdateBaseDto
{
    public Guid ReceiverAccountCode { get; set; }
    public Guid GiverAccountCode { get; set; }
}