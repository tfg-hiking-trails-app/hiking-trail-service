using RabbitMQ.Client;

namespace HikingTrailService.Domain.Interfaces;

public interface IRabbitMqQueueProvider
{
    Task<IChannel> GetChannelAsync(string exchangeName, string queueName);
}