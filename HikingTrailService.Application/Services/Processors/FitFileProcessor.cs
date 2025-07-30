using HikingTrailService.Application.DTOs;
using HikingTrailService.Domain.Interfaces.Messages;

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
        FitDataResponseDto fitDataResponseDto = await _queueConsumer.BasicConsumeAsync<FitDataResponseDto>(ExtensionFile);
    }
}