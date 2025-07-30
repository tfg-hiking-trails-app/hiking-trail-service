using RabbitMQ.Client;

namespace HikingTrailService.Domain.Interfaces.Messages;

public interface IRabbitMqConnectionProvider : IDisposable
{
    Task<IConnection> GetConnectionAsync();
}