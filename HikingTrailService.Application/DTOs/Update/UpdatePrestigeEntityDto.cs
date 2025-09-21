namespace HikingTrailService.Application.DTOs.Update;

public record UpdatePrestigeEntityDto
{
    public Guid? HikingTrailCode { get; set; }
    public Guid? ReceiverAccountCode { get; set; }
    public Guid? GiverAccountCode { get; set; }
}