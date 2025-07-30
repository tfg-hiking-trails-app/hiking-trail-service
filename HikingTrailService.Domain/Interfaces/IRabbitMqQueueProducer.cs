namespace HikingTrailService.Domain.Interfaces;

public interface IRabbitMqQueueProducer
{
    Task BasicPublishAsync(string name, byte[] body);
}