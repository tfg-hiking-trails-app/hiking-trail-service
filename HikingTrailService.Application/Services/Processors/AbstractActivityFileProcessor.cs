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
     
        await SaveFileAsync(file);
        
        file.Content = Stream.Null;
        
        await SendFileAsync(file);
    }
    
    private async Task SaveFileAsync(ActivityFileEntityDto file)
    {
        if (string.IsNullOrEmpty(file.FileName))
            throw new ArgumentNullException(nameof(file.FileName));
        
        await using FileStream outStream = File.Create(GetFullPath(file.FileName));
        await using Stream inStream = file.Content ?? throw new ArgumentNullException(nameof(file.Content));

        await inStream.CopyToAsync(outStream);
    }

    private async Task SendFileAsync(ActivityFileEntityDto file)
    {
        if (string.IsNullOrEmpty(file.FileName))
            throw new ArgumentNullException(nameof(file.FileName));
        
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