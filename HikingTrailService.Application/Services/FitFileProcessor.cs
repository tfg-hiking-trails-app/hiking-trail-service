using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Application.Services;

public class FitFileProcessor : AbstractActivityFileProcessor
{
    public FitFileProcessor(IRabbitMqQueueProducer queueProducer) : base(queueProducer)
    {
    }

    public override string ExtensionFile => ".fit";
}