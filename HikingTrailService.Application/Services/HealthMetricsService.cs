using AutoMapper;
using Common.Application.Services;
using Common.Application.Utils;
using Common.Domain.Interfaces;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Application.Services;

public class HealthMetricsService : AbstractService<HealthMetrics, HealthMetricsEntityDto, CreateHealthMetricsEntityDto, 
    UpdateHealthMetricsEntityDto>, IHealthMetricsService
{
    public HealthMetricsService(IRepository<HealthMetrics> repository, IMapper mapper) 
        : base(repository, mapper)
    {
    }

    protected override void CheckDataValidity(CreateHealthMetricsEntityDto createEntityDto)
    {
        Validator.CheckGuid(createEntityDto.HikingTrailCode);

        foreach (var item in GetIntegerProperties(createEntityDto))
            Validator.CheckPositiveValue(item.Value, item.Field);
        
        foreach (var item in GetDoubleProperties(createEntityDto))
            Validator.CheckPositiveValue(item.Value, item.Field);
    }

    private (int Value, string Field)[] GetIntegerProperties(CreateHealthMetricsEntityDto createEntityDto)
    {
        return new[]
            {
                (createEntityDto.MinHeartRate, nameof(createEntityDto.MinHeartRate)),
                (createEntityDto.MaxHeartRate, nameof(createEntityDto.MaxHeartRate)),
                (createEntityDto.AverageHeartRate, nameof(createEntityDto.AverageHeartRate)),
                (createEntityDto.CaloriesBurned, nameof(createEntityDto.CaloriesBurned)),
                (createEntityDto.Steps, nameof(createEntityDto.Steps)),
                (createEntityDto.ElevationGain, nameof(createEntityDto.ElevationGain))
            }
            .Where(x => x.Item1.HasValue)
            .Select(x => (x.Item1!.Value, x.Item2))
            .ToArray();
    }

    private (double Value, string Field)[] GetDoubleProperties(CreateHealthMetricsEntityDto createEntityDto)
    {
        return new[]
            {
                (createEntityDto.MinPace, nameof(createEntityDto.MinPace)),
                (createEntityDto.MaxPace, nameof(createEntityDto.MaxPace)),
                (createEntityDto.AveragePace, nameof(createEntityDto.AveragePace)),
                (createEntityDto.MinSpeed, nameof(createEntityDto.MinSpeed)),
                (createEntityDto.MaxSpeed, nameof(createEntityDto.MaxSpeed)),
                (createEntityDto.AverageSpeed, nameof(createEntityDto.AverageSpeed))
            }
            .Where(x => x.Item1.HasValue)
            .Select(x => (x.Item1!.Value, x.Item2))
            .ToArray();
    }
    
}