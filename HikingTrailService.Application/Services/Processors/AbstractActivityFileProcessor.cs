using System.Text;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.Interfaces.Processors;
using HikingTrailService.Domain.Interfaces.Messages;

namespace HikingTrailService.Application.Services.Processors;

public abstract class AbstractActivityFileProcessor : IActivityFileProcessor
{
    protected readonly IRabbitMqQueueProducer _queueProducer;
    protected readonly IRabbitMqQueueConsumer _queueConsumer;
    private const string Folder = "/shared/data";

    protected AbstractActivityFileProcessor(
        IRabbitMqQueueProducer queueProducer,
        IRabbitMqQueueConsumer queueConsumer)
    {
        _queueProducer = queueProducer;
        _queueConsumer = queueConsumer;
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
        
        await _queueProducer.BasicPublishAsync(ExtensionFile, Encoding.UTF8.GetBytes(file.FileName));
    }

    private string GetFullPath(string fileName)
    {
        return Path.Combine(Folder, fileName);
    }
    
}