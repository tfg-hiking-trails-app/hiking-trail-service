using HikingTrailService.Application.Interfaces;

namespace HikingTrailService.Application.Services;

public class ActivityFileProcessorFactory
{
    private readonly Dictionary<string, IActivityFileProcessor> _processors;

    public ActivityFileProcessorFactory(IEnumerable<IActivityFileProcessor> processors)
    {
        _processors = processors.ToDictionary(x => 
            x.ExtensionFile, 
            x => x);
    }

    public IActivityFileProcessor? GetProcessor(string extensionFile)
    {
        return _processors.GetValueOrDefault(extensionFile);
    }
}