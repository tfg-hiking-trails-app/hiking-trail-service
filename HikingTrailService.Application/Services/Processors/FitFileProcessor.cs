using AutoMapper;
using Common.Domain.Interfaces.Messaging;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Messaging;
using HikingTrailService.Application.Interfaces;

namespace HikingTrailService.Application.Services.Processors;

public class FitFileProcessor : AbstractActivityFileProcessor
{
    private readonly IMapper _mapper;
    private readonly IHikingTrailService _hikingTrailService;
    private readonly IMetricsService _metricsService;
    
    public FitFileProcessor(
        IMapper mapper,
        IRabbitMqQueueProducer queueProducer,
        IRabbitMqQueueConsumer queueConsumer,
        IHikingTrailService hikingTrailService,
        IMetricsService metricsService) : base(queueProducer, queueConsumer)
    {
        _mapper = mapper;
        _hikingTrailService = hikingTrailService;
        _metricsService = metricsService;
    }

    public override string ExtensionFile => ".fit";

    public override async Task ProcessAsync(ActivityFileEntityDto file)
    {
        await base.ProcessAsync(file);

        await ReceiveResponse();
    }

    private async Task ReceiveResponse()
    {
        FitFileDataEntityDto fitFileDataEntityDto = await QueueConsumer.BasicConsumeAsync<FitFileDataEntityDto>();

        CreateHikingTrailEntityDto createHikingTrail = _mapper.Map<CreateHikingTrailEntityDto>(fitFileDataEntityDto);
        
        await _hikingTrailService.CreateAsync(createHikingTrail);
        
        CreateMetricsEntityDto createMetrics = _mapper.Map<CreateMetricsEntityDto>(fitFileDataEntityDto);
        
        await _metricsService.CreateAsync(createMetrics);
    }
}