using HikingTrailService.Domain.Interfaces;
using RabbitMQ.Client;

namespace HikingTrailService.Infrastructure.Messaging.Producer;

public class RabbitMqQueueProducer : IRabbitMqQueueProducer
{
    private readonly IRabbitMqQueueProvider _channelProvider;
    
    private readonly Func<string, string> _queueName = extension => $"read-{ extension.Replace(".", "") }-file";

    public RabbitMqQueueProducer(IRabbitMqQueueProvider channelProvider)
    {
        _channelProvider = channelProvider;
    }
    
    public async Task BasicPublishAsync(string routingKey, byte[] body)
    {
        string exchangeName = GetExchangeName();
        string queueName = _queueName(routingKey);
        
        IChannel channel = await _channelProvider.GetChannelAsync(exchangeName, queueName);
        
        await channel.BasicPublishAsync(exchangeName, queueName, body);
    }

    private string GetExchangeName()
    {
        string? exchangeName = Environment.GetEnvironmentVariable("RABBITMQ_EXCHANGE_HIKING_TRAIL_SERVICE");

        if (string.IsNullOrEmpty(exchangeName))
            throw new Exception("Exchange name not set");
        
        return exchangeName;
    }
    
}