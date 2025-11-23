using Common.Application.DTOs.Filter;
using Common.Application.Pagination;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.Interfaces;

namespace HikingTrailService.Application.Services;

public class RecommenderService : IRecommenderService
{
    private readonly IMetricsScoreService _metricsScoreRepository;
    
    public RecommenderService(
        IMetricsScoreService metricsScoreRepository)
    {
        _metricsScoreRepository = metricsScoreRepository;
    }
    
    public async Task<Page<HikingTrailEntityDto>> RecommenderAsync(
        Guid accountCode, 
        List<HikingTrailEntityDto> hikingTrails, 
        FilterEntityDto filterEntityDto,
        CancellationToken cancellationToken)
    {
        MetricsScoreEntityDto metricsScoreEntityDto = await _metricsScoreRepository.GetByAccountCodeAsync(accountCode);
        
        List<HikingTrailEntityDto> scoredHikingTrails = hikingTrails
            .Select(h =>
            {
                MetricsEntityDto? metrics = h.Metrics.FirstOrDefault();
                double score = metrics is not null
                    ? ScoreHikingTrail(metrics, metricsScoreEntityDto)
                    : 0;

                return new
                {
                    HikingTrail = h,
                    Score = score
                };
            })
            .OrderByDescending(h => h.Score)
            .Skip((filterEntityDto.PageNumber - 1) * filterEntityDto.PageSize)
            .Take(filterEntityDto.PageSize)
            .Select(h => h.HikingTrail)
            .ToList();

        return new Page<HikingTrailEntityDto>(
            scoredHikingTrails,
            filterEntityDto.PageNumber, 
            filterEntityDto.PageSize, 
            hikingTrails.Count);
    }

    private double NormalizeUp(double value, double min, double max)
    {
        if (max < min)
            return 0;
        
        double result = (value - min) / (max - min);
        
        return Math.Clamp(result, 0, 1);
    }

    private double NormalizeDown(double value, double min, double max)
    {
        if (max < min)
            return 0;
        
        double result = (max - value) / (max - min);
        
        return Math.Clamp(result, 0, 1);
    }

    private double NormalizeTarget(double value, double target, double band)
    {
        if (band <= 0)
            return 0;
        
        double result = 1 - Math.Abs(value - target) / band;
        
        return Math.Clamp(result, 0, 1);
    }

    private double ScoreHikingTrail(MetricsEntityDto metrics, MetricsScoreEntityDto scores)
    {
        double totalScore = 0;
        double acc = 0;

        // Distance
        if (scores.Distance > 0)
        {
            double value = NormalizeUp(metrics.Distance, 1000, 30000);
            
            acc += scores.Distance * value;
            totalScore += scores.Distance;
        }
        
        // Duration
        if (metrics.Duration is { } duration && scores.Duration > 0)
        {
            double value = NormalizeTarget(duration, 7200, 3600);
            acc += scores.Duration * value;
            totalScore += scores.Duration;
        }

        // Steps
        if (metrics.Steps is { } steps && scores.Steps > 0)
        {
            double value = NormalizeUp(steps, 1500, 40000);
            acc += scores.Steps * value;
            totalScore += scores.Steps;
        }

        // Calories
        if (metrics.Calories is { } calories && scores.Calories > 0)
        {
            double value = NormalizeUp(calories, 100, 1500);
            acc += scores.Calories * value;
            totalScore += scores.Calories;
        }

        // Pace
        if (metrics.AveragePace is { } avgPace && scores.Pace > 0)
        {
            double value = NormalizeDown(avgPace, 240, 900);
            acc += scores.Pace * value;
            totalScore += scores.Pace;
        }

        // Elevation
        if (metrics.ElevationGain is { } elevationGain && scores.Elevation > 0)
        {
            double value = NormalizeUp(elevationGain, 50, 1500);
            acc += scores.Elevation * value;
            totalScore += scores.Elevation;
        }

        // HeartRate
        if (metrics.AverageHeartRate is { } avgHr && scores.HeartRate > 0)
        {
            double value = NormalizeTarget(avgHr, 130, 25);
            acc += scores.HeartRate * value;
            totalScore += scores.HeartRate;
        }

        // Speed
        if (metrics.AverageSpeed is { } avgSpeed && scores.Speed > 0)
        {
            double value = NormalizeUp(avgSpeed, 0.8, 2.0);
            acc += scores.Speed * value;
            totalScore += scores.Speed;
        }

        if (totalScore <= 0d)
            return 0d;
        
        return 100d * acc / totalScore;
    }
    
}