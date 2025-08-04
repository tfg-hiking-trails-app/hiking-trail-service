using Common.Domain.Interfaces.Messaging;
using Common.Infrastructure.Messaging;

namespace HikingTrailService.Infrastructure.Messaging.Producer;

public class RabbitMqQueueProducer : AbstractRabbitMqQueueProducer
{
    public override string QueueName { get; }
    public override string ExchangeName { get; }

    public RabbitMqQueueProducer(IRabbitMqQueueProvider channelProvider) : base(channelProvider)
    {
        QueueName = GetUsingEnvironmentVariable("RABBITMQ_QUEUE_HIKING_TO_FITDATA");
        ExchangeName = GetUsingEnvironmentVariable("RABBITMQ_EXCHANGE_HIKING_TRAIL_SERVICE");
    }
    
}