using HikingTrailService.Domain.Interfaces.Messages;

namespace HikingTrailService.Application.Services.Processors;

public class GpxFileProcessor : AbstractActivityFileProcessor
{
    public GpxFileProcessor(
        IRabbitMqQueueProducer queueProducer,
        IRabbitMqQueueConsumer queueConsumer) : base(queueProducer, queueConsumer)
    {
    }

    public override string ExtensionFile => ".gpx";
}