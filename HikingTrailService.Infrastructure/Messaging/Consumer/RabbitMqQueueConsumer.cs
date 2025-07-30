using System.Text;
using HikingTrailService.Domain.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace HikingTrailService.Infrastructure.Messaging.Consumer;

public class RabbitMqQueueConsumer : IRabbitMqQueueConsumer
{
    private readonly IRabbitMqQueueProvider _channelProvider;
    
    private readonly Func<string, string> _queueName = extension => $"data-response-{ extension.Replace(".", "") }-file";

    private RabbitMqQueueConsumer(IRabbitMqQueueProvider channelProvider)
    {
        _channelProvider = channelProvider;
    }
    
    public async Task BasicConsumeAsync(string routingKey)
    {
        string exchangeName = GetExchangeName();
        string queueName = _queueName(routingKey);
        
        IChannel channel = await _channelProvider.GetChannelAsync(exchangeName, queueName);
        
        AsyncEventingBasicConsumer consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += (model, ea) =>
        {
            byte[] body = ea.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);
            
            return Task.CompletedTask;
        };

        await channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer);
    }
    
    private string GetExchangeName()
    {
        string? exchangeName = Environment.GetEnvironmentVariable("RABBITMQ_EXCHANGE_FIT_DATA_SERVICE");

        if (string.IsNullOrEmpty(exchangeName))
            throw new Exception("Exchange name not set");
        
        return exchangeName;
    }
    
}