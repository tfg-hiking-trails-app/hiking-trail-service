using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.Interfaces;

namespace HikingTrailService.Application.Services;

public class FitFileProcessor : IActivityFileProcessor
{
    public string ExtensionFile => ".fit";
    
    public async Task ProcessAsync(ActivityFileEntityDto file)
    {
        file.FileName = Guid.NewGuid() + ExtensionFile;
     
        await SaveFile(file);
        
        // TODO: Enviar al FitDataProcessor el FileName como message para que lo lea
        // ...
        
        Console.WriteLine($"Processing file { file.FileName }");
    }

    private async Task SaveFile(ActivityFileEntityDto file)
    {
        await using FileStream fileStream = File.Create($"/shared/data/{ file.FileName }");
        
        await file.Content.CopyToAsync(fileStream);
    }
}