using RabbitMQ.Client;

namespace HikingTrailService.Domain.Interfaces;

public interface IRabbitMqChannelProvider : IDisposable
{
    Task<IChannel> GetChannelAsync();
}