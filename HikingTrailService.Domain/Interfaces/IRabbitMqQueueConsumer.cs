namespace HikingTrailService.Domain.Interfaces;

public interface IRabbitMqQueueConsumer
{
    Task BasicConsumeAsync(string routingKey);
}