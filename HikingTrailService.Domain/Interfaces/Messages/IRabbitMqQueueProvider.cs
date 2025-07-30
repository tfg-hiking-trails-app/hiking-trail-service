using RabbitMQ.Client;

namespace HikingTrailService.Domain.Interfaces.Messages;

public interface IRabbitMqQueueProvider
{
    Task<IChannel> GetChannelAsync(string exchangeName, string queueName);
}