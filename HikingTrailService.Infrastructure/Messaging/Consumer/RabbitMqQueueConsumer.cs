using System.Text;
using System.Text.Json;
using HikingTrailService.Domain.Interfaces.Messages;
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
    
    public async Task<T> BasicConsumeAsync<T>(string routingKey)
    {
        string exchangeName = GetExchangeName();
        string queueName = _queueName(routingKey);
        
        TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
        
        IChannel channel = await _channelProvider.GetChannelAsync(exchangeName, queueName);
        AsyncEventingBasicConsumer consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (model, ea) =>
        {
            try
            {
                byte[] body = ea.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);
            
                T? result = JsonSerializer.Deserialize<T>(message);

                if (result is null)
                    throw new Exception($"Error trying to deserialize the message: { message }");
                
                tcs.SetResult(result);
            }
            catch (Exception e)
            {
                tcs.TrySetException(e);
            }

            await Task.CompletedTask;
        };

        await channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer);
        
        return await tcs.Task;
    }
    
    private string GetExchangeName()
    {
        string? exchangeName = Environment.GetEnvironmentVariable("RABBITMQ_EXCHANGE_FIT_DATA_SERVICE");

        if (string.IsNullOrEmpty(exchangeName))
            throw new Exception("Exchange name not set");
        
        return exchangeName;
    }
    
}