using RabbitMQ.Client;

namespace HikingTrailService.Domain.Interfaces;

public interface IRabbitMqConnectionProvider : IDisposable
{
    Task<IConnection> GetConnectionAsync();
}