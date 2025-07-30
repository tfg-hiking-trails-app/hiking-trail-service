using System.Text;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.Domain.Interfaces;
using RabbitMQ.Client;

namespace HikingTrailService.Application.Services;

public abstract class AbstractActivityFileProcessor : IActivityFileProcessor
{
    private readonly IRabbitMqQueueProducer _queueProducer;
    private const string Folder = "/shared/data";

    protected AbstractActivityFileProcessor(IRabbitMqQueueProducer queueProducer)
    {
        _queueProducer = queueProducer;
    }
    
    public abstract string ExtensionFile { get; }

    public async Task ProcessAsync(ActivityFileEntityDto file)
    {
        file.FileName = Guid.NewGuid() + ExtensionFile;
     
        await SaveFile(file);
        
        await SendFile(file);
        
        Console.WriteLine($"Processing file { file.FileName }");
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