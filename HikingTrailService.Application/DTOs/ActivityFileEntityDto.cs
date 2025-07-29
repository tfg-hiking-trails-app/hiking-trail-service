namespace HikingTrailService.Application.DTOs;

public class ActivityFileEntityDto
{
    public string? ContentType { get; set; }
    public string? ContentDisposition { get; set; }
    public long Length { get; set; }
    public string? Name { get; set; }
    public string? FileName { get; set; }
    public Stream Content { get; set; } = new MemoryStream();
}