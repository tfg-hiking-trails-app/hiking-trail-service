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

    public virtual async Task ProcessAsync(ActivityFileEntityDto file)
    {
        file.FileName = Guid.NewGuid() + ExtensionFile;
     
        await SaveFile(file);
        
        await SendFile(file);
    }
    
    private async Task SaveFile(ActivityFileEntityDto file)
    {
        if (string.IsNullOrEmpty(file.FileName))
            throw new ArgumentNullException(nameof(file.FileName));
        
        await using FileStream fileStream = File.Create(GetFullPath(file.FileName));
        
        await file.Content.CopyToAsync(fileStream);
    }

    private async Task SendFile(ActivityFileEntityDto file)
    {
        if (string.IsNullOrEmpty(file.FileName))
            throw new ArgumentNullException(nameof(file.FileName));
        
        file.Content = Stream.Null;

        string response = JsonSerializer.Serialize<ActivityFileResponseDto>(
            new ActivityFileResponseDto 
            {
                ContentType = file.ContentType,
                FileName = file.FileName,
            });
        
        await QueueProducer.BasicPublishAsync(Encoding.UTF8.GetBytes(response));
    }

    private string GetFullPath(string fileName)
    {
        return Path.Combine(Folder, fileName);
    }
    
}