using Common.Application.DTOs.Create;

namespace HikingTrailService.Application.DTOs.Create;

public record CreatePrestigeEntityDto : CreateBaseEntityDto
{
    public Guid? HikingTrailCode { get; set; }
    public Guid? ReceiverAccountCode { get; set; }
    public Guid? GiverAccountCode { get; set; }
}