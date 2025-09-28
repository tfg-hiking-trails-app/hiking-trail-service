using HikingTrailService.Application.DTOs;

namespace HikingTrailService.Application.Interfaces.Processors;

public interface IActivityFileProcessor
{
    string ExtensionFile { get; }
    Task<Guid> ProcessAsync(ActivityFileEntityDto file);
}