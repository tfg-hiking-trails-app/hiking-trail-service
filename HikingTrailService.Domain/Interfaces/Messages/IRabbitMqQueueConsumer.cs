namespace HikingTrailService.Domain.Interfaces.Messages;

public interface IRabbitMqQueueConsumer
{
    Task<T> BasicConsumeAsync<T>(string routingKey);
}