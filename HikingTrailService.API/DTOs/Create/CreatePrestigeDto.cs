using Common.API.DTOs.Create;

namespace HikingTrailService.DTOs.Create;

public record CreatePrestigeDto : CreateBaseDto
{
    public Guid? HikingTrailCode { get; set; }
    public Guid ReceiverAccountCode { get; set; }
    public Guid GiverAccountCode { get; set; }
}