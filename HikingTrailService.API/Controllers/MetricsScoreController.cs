using AutoMapper;
using Common.API.Controllers;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.DTOs;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Update;
using Microsoft.AspNetCore.Mvc;

namespace HikingTrailService.Controllers;

[Route("api/metrics-score")]
public class MetricsScoreController : AbstractCrudController<MetricsScoreDto, CreateMetricsScoreDto, UpdateMetricsDto, 
    MetricsScoreEntityDto, CreateMetricsScoreEntityDto, UpdateMetricsScoreEntityDto>
{
    public MetricsScoreController(
        IMetricsScoreService service, 
        IMapper mapper) : base(service, mapper)
    {
    }
}