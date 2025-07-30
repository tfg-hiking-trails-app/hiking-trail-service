using RabbitMQ.Client;

namespace HikingTrailService.Domain.Interfaces.Messages;

public interface IRabbitMqChannelProvider : IDisposable
{
    Task<IChannel> GetChannelAsync();
}