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
    
    public FitFileProcessor(
        IMapper mapper,
        IRabbitMqQueueProducer queueProducer,
        IRabbitMqQueueConsumer queueConsumer,
        IHikingTrailService hikingTrailService) : base(queueProducer, queueConsumer)
    {
        _mapper = mapper;
        _hikingTrailService = hikingTrailService;
    }

    public override string ExtensionFile => ".fit";

    public override async Task<Guid> ProcessAsync(ActivityFileEntityDto file)
    {
        await base.ProcessAsync(file);

        return await ReceiveResponseAsync(file.UserCode);
    }

    private async Task<Guid> ReceiveResponseAsync(Guid userCode)
    {
        FitFileDataEntityDto fitFileDataEntityDto = await QueueConsumer.BasicConsumeAsync<FitFileDataEntityDto>();

        CreateHikingTrailEntityDto createHikingTrail = _mapper.Map<CreateHikingTrailEntityDto>(fitFileDataEntityDto);
        CreateMetricsEntityDto createMetrics = _mapper.Map<CreateMetricsEntityDto>(fitFileDataEntityDto);
        
        createHikingTrail.AccountCode = userCode;
        createHikingTrail.Metrics = createMetrics;
        
        return await _hikingTrailService.CreateAsync(createHikingTrail);
    }
}