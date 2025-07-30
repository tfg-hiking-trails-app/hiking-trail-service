using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Application.Services;

public class GpxFileProcessor : AbstractActivityFileProcessor
{
    public GpxFileProcessor(IRabbitMqQueueProducer queueProducer) : base(queueProducer)
    {
    }

    public override string ExtensionFile => ".gpx";
}