using Common.Domain.Interfaces.Messaging;
using HikingTrailService.Application.DTOs;

namespace HikingTrailService.Application.Services.Processors;

public class FitFileProcessor : AbstractActivityFileProcessor
{
    public FitFileProcessor(
        IRabbitMqQueueProducer queueProducer,
        IRabbitMqQueueConsumer queueConsumer) : base(queueProducer, queueConsumer)
    {
    }

    public override string ExtensionFile => ".fit";

    public override async Task ProcessAsync(ActivityFileEntityDto file)
    {
        await base.ProcessAsync(file);

        await ReceiveResponse();
    }

    private async Task ReceiveResponse()
    {
        FitDataResponseDto fitDataResponseDto = await QueueConsumer.BasicConsumeAsync<FitDataResponseDto>();
    }
}