using HikingTrailService.Application.Interfaces;
using HikingTrailService.Application.Services;
using HikingTrailService.DTOs.Mapping;
using HikingTrailService.Infrastructure.Data;
using Microsoft.OpenApi.Models;

namespace HikingTrailService.Extensions;

public static class ServiceConfigurationExtension
{
    public static void ConfigureServicesCollection(this IServiceCollection services)
    {
        services.AddRouting(options => options.LowercaseUrls = true);

        services.AddDbContext<HikingTrailServiceDbContext>();

        services.AddAutoMapper();
        
        services.AddServices();
        
        services.AddRepositories();
        
        services.AddSwaggerGen();
    }
    
    private static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IActivityFileProcessor, FitFileProcessor>();
        
        services.AddSingleton<ActivityFileProcessorFactory>();
    }
    
    private static void AddRepositories(this IServiceCollection services)
    {
        
    }

    private static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(ActivityFileProfile).Assembly);
    }
    
    private static void AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Hiking Trail microservice", 
                Version = "3.0.1"
            });
        });
    }
    
}