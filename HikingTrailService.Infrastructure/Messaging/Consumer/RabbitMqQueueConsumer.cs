using Common.Domain.Interfaces.Messaging;
using Common.Infrastructure.Messaging;

namespace HikingTrailService.Infrastructure.Messaging.Consumer;

public class RabbitMqQueueConsumer : AbstractRabbitMqQueueConsumer
{
    public override string QueueName { get; }
    public override string ExchangeName { get; }

    public RabbitMqQueueConsumer(IRabbitMqQueueProvider channelProvider) : base(channelProvider)
    {
        QueueName = GetUsingEnvironmentVariable("RABBITMQ_QUEUE_FITDATA_TO_HIKING");
        ExchangeName = GetUsingEnvironmentVariable("RABBITMQ_EXCHANGE_FIT_DATA_SERVICE");
    }

}