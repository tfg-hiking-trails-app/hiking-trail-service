using HikingTrailService.Application.Interfaces;
using HikingTrailService.Application.Services;
using HikingTrailService.Domain.Interfaces;
using HikingTrailService.DTOs.Mapping;
using HikingTrailService.Infrastructure.Data;
using HikingTrailService.Infrastructure.Messaging.Configuration;
using Microsoft.OpenApi.Models;

namespace HikingTrailService.Extensions;

public static class ServiceConfigurationExtension
{
    public static void ConfigureServicesCollection(this IServiceCollection services)
    {
        services.AddRouting(options => options.LowercaseUrls = true);

        services.AddDbContext<HikingTrailServiceDbContext>();
        
        services.AddAutoMapper();
        
        services.AddRabbitMq();
        
        services.AddServices();
        
        services.AddRepositories();
        
        services.AddSwaggerGen();
    }
    
    private static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IActivityFileProcessor, FitFileProcessor>();
        services.AddTransient<IActivityFileProcessor, GpxFileProcessor>();
        
        services.AddScoped<ActivityFileProcessorFactory>();
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

    private static void AddRabbitMq(this IServiceCollection services)
    {
        services.AddSingleton<IRabbitMqConnectionProvider, RabbitMqConnectionProvider>();

        services.AddScoped<IRabbitMqChannelProvider, RabbitMqChannelProvider>();
        
        services.AddScoped<IRabbitMqQueueProducer, RabbitMqQueueProducer>();
    }
    
}