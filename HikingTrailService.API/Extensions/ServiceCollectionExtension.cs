using Common.API.DTOs.Mapping;
using Common.Application.Interfaces;
using Common.Domain.Interfaces.Messaging;
using Common.Infrastructure.Data.Configuration.Mapping;
using Common.Infrastructure.Messaging.Configuration;
using Common.Infrastructure.Security.Tokens;
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

public static class ServiceCollectionExtension
{
    public static void ServiceCollectionConfiguration(this IServiceCollection services)
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
        services.AddScoped<ITokenManager, TokenManager>();
        services.AddScoped<IDifficultyLevelService, DifficultyLevelService>();
        services.AddScoped<IHikingTrailService, Application.Services.HikingTrailService>();
        services.AddScoped<IMetricsService, MetricsService>();
        services.AddScoped<IImagesService, ImagesService>();
        services.AddScoped<ITerrainTypeService, TerrainTypeService>();
        services.AddScoped<ITrailTypeService, TrailTypeService>();
    }
    
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDifficultyLevelRepository, DifficultyLevelRepository>();
        services.AddScoped<IHikingTrailRepository, HikingTrailRepository>();
        services.AddScoped<IMetricsRepository, MetricsRepository>();
        services.AddScoped<IImagesRepository, ImagesRepository>();
        services.AddScoped<ITerrainTypeRepository, TerrainTypeRepository>();
        services.AddScoped<ITrailTypeRepository, TrailTypeRepository>();
    }

    private static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(CommonProfile).Assembly,
            typeof(HikingTrailProfile).Assembly,
            typeof(DifficultyLevelProfile).Assembly,
            typeof(MetricsProfile).Assembly,
            typeof(ActivityFileProfile).Assembly,
            typeof(FitFileDataProfile).Assembly,
            typeof(ImagesProfile).Assembly,
            typeof(TerrainTypeProfile).Assembly,
            typeof(TrailTypeProfile).Assembly,
            typeof(CommonEntityProfile).Assembly,
            typeof(HikingTrailEntityProfile).Assembly,
            typeof(DifficultyLevelEntityProfile).Assembly,
            typeof(MetricsEntityProfile).Assembly,
            typeof(ImagesEntityProfile).Assembly,
            typeof(TerrainTypeEntityProfile).Assembly,
            typeof(TrailTypeEntityProfile).Assembly);
    }
    
    private static void AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Hiking Trail Microservice", 
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