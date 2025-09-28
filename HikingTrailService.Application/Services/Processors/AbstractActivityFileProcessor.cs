using System.Text;
using System.Text.Json;
using Common.Domain.Interfaces.Messaging;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Messaging;
using HikingTrailService.Application.Interfaces.Processors;

namespace HikingTrailService.Application.Services.Processors;

public abstract class AbstractActivityFileProcessor : IActivityFileProcessor
{
    protected readonly IRabbitMqQueueProducer QueueProducer;
    protected readonly IRabbitMqQueueConsumer QueueConsumer;
    private const string Folder = "/shared/data";

    protected AbstractActivityFileProcessor(
        IRabbitMqQueueProducer queueProducer,
        IRabbitMqQueueConsumer queueConsumer)
    {
        QueueProducer = queueProducer;
        QueueConsumer = queueConsumer;
    }
    
    public abstract string ExtensionFile { get; }

    public virtual async Task<Guid> ProcessAsync(ActivityFileEntityDto file)
    {
        Guid code = Guid.NewGuid();
        
        file.FileName = code + ExtensionFile;
        await SaveFileAsync(file);
        file.Content = [];
        await SendFileAsync(file);
        
        return code;
    }
    
    private async Task SaveFileAsync(ActivityFileEntityDto file)
    {
        if (string.IsNullOrEmpty(file.FileName))
            throw new ArgumentNullException(nameof(file.FileName));
        
        if (file.Content.Length == 0)
            throw new ArgumentNullException(nameof(file.Content.Length));
        
        string path = GetFullPath(file.FileName);
        
        await File.WriteAllBytesAsync(path, file.Content);
    }

    private async Task SendFileAsync(ActivityFileEntityDto file)
    {
        if (string.IsNullOrEmpty(file.FileName))
            throw new ArgumentNullException(nameof(file.FileName));
        
        string body = JsonSerializer.Serialize<ActivityFileResponseDto>(
            new ActivityFileResponseDto 
            {
                ContentType = file.ContentType,
                FileName = file.FileName,
            });
        
        await QueueProducer.BasicPublishAsync(Encoding.UTF8.GetBytes(body));
    }

    private string GetFullPath(string fileName)
    {
        return Path.Combine(Folder, fileName);
    }
    
}