namespace HikingTrailService.DTOs.Delete;

public record DeletePrestigeDto
{
    public Guid? HikingTrailCode { get; set; }
    public Guid? ReceiverAccountCode { get; set; }
    public Guid? GiverAccountCode { get; set; }
}