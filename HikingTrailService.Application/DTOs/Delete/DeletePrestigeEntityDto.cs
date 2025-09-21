namespace HikingTrailService.Application.DTOs.Delete;

public record DeletePrestigeEntityDto
{
    public Guid? HikingTrailCode { get; set; }
    public Guid? ReceiverAccountCode { get; set; }
    public Guid? GiverAccountCode { get; set; }
}