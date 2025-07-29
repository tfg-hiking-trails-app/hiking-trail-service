using HikingTrailService.Application.DTOs;

namespace HikingTrailService.Application.Interfaces;

public interface IActivityFileProcessor
{
    string ExtensionFile { get; }
    Task ProcessAsync(ActivityFileEntityDto file);
}