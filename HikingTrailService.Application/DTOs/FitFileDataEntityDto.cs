﻿namespace HikingTrailService.Application.DTOs;

public record FitFileDataEntityDto
{
    public required Guid HikingTrailCode { get; set; }
    public required string Name { get; set; }
    public required double Distance { get; set; }
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }
    public required double Duration { get; set; }
    public required double UbicationLatitude { get; set; }
    public required double UbicationLongitude { get; set; }
}