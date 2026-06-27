namespace HikingTrailService.Application.DTOs.Messaging;

/// <summary>
/// Envelope received from the fit-data-service. Either carries the decoded
/// activity data or a rejection reason (e.g. the activity is not a supported
/// hiking-trail sport).
/// </summary>
public record FitFileResultDto
{
    public bool IsValid { get; init; }
    public string? RejectionReason { get; init; }
    public FitFileDataEntityDto? Data { get; init; }
}
