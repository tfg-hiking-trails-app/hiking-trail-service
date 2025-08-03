using Common.API.DTOs.Mapping;
using Common.Domain.Interfaces.Messaging;
using Common.Infrastructure.Data.Configuration.Mapping;
using Common.Infrastructure.Messaging.Configuration;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.Application.Interfaces.Processors;
using HikingTrailService.Application.Services;
using HikingTrailService.Application.Services.Processors;
using HikingTrailService.Domain.Interfaces;
using HikingTrailService.DTOs.Mapping;
using HikingTrailService.Infrastructure.Data;
using HikingTrailService.Infrastructure.Data.Configurations.Mapping;
using HikingTrailService.Infrastructure.Data.Repositories;
using HikingTrailService.Infrastructure.Messaging.Consumer;
using HikingTrailService.Infrastructure.Messaging.Producer;
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
        // Processors
        services.AddScoped<IActivityFileProcessor, FitFileProcessor>();
        services.AddScoped<IActivityFileProcessor, GpxFileProcessor>();
        
        // Factories
        services.AddScoped<ActivityFileProcessorFactory>();
        
        // Services
        services.AddScoped<IDifficultyLevelService, DifficultyLevelService>();
        services.AddScoped<IHealthMetricsService, HealthMetricsService>();
        services.AddScoped<IHikingTrailService, Application.Services.HikingTrailService>();
    }
    
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDifficultyLevelRepository, DifficultyLevelRepository>();
        services.AddScoped<IHealthMetricsRepository, HealthMetricsRepository>();
        services.AddScoped<IHikingTrailRepository, HikingTrailRepository>();
    }

    private static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(CommonProfile).Assembly,
            typeof(HikingTrailProfile).Assembly,
            typeof(HealthMetricsProfile).Assembly,
            typeof(DifficultyLevelProfile).Assembly,
            typeof(ActivityFileProfile).Assembly,
            typeof(FitDataResponseProfile).Assembly,
            typeof(CommonEntityProfile).Assembly,
            typeof(HikingTrailEntityProfile).Assembly,
            typeof(HealthMetricsEntityProfile).Assembly,
            typeof(DifficultyLevelEntityProfile).Assembly);
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
        // Providers
        services.AddScoped<IRabbitMqConnectionProvider, RabbitMqConnectionProvider>();
        services.AddScoped<IRabbitMqChannelProvider, RabbitMqChannelProvider>();
        services.AddScoped<IRabbitMqQueueProvider, RabbitMqQueueProvider>();
        
        // Processors
        services.AddScoped<IRabbitMqQueueProducer, RabbitMqQueueProducer>();
        services.AddScoped<IRabbitMqQueueConsumer, RabbitMqQueueConsumer>();
    }
    
}