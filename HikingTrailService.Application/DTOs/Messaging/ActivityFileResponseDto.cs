namespace HikingTrailService.Application.DTOs.Messaging;

public record ActivityFileResponseDto
{
    public string? ContentType { get; set; }
    
    public required string FileName { get; set; }
}