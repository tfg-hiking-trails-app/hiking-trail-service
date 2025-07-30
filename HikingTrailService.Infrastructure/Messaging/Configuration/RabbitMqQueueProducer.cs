using HikingTrailService.Domain.Interfaces;
using RabbitMQ.Client;

namespace HikingTrailService.Infrastructure.Messaging.Configuration;

public class RabbitMqQueueProducer : IRabbitMqQueueProducer
{
    private readonly IRabbitMqChannelProvider _channelProvider;
    
    private readonly Func<string, string> _queueName = extension => $"read-{ extension }-file";

    public RabbitMqQueueProducer(IRabbitMqChannelProvider channelProvider)
    {
        _channelProvider = channelProvider;
    }
    
    public async Task BasicPublishAsync(string name, byte[] body)
    {
        string queueName = _queueName(name);
        IChannel channel = await _channelProvider.GetChannelAsync();
        
        await channel.ExchangeDeclareAsync(queueName, ExchangeType.Direct);
        await channel.QueueDeclareAsync(queueName, true, false, false);
        await channel.QueueBindAsync(queueName, queueName, queueName);
        await channel.BasicPublishAsync(queueName, queueName, body);
    }
}