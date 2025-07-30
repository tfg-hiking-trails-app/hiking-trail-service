namespace HikingTrailService.Domain.Interfaces.Messages;

public interface IRabbitMqQueueProducer
{
    Task BasicPublishAsync(string routingKey, byte[] body);
}