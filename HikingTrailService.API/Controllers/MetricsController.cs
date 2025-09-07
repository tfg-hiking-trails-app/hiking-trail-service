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

[Route("api/metrics")]
public class MetricsController : AbstractCrudController<
    MetricsDto, CreateMetricsDto, UpdateMetricsDto, 
    MetricsEntityDto, CreateMetricsEntityDto, UpdateMetricsEntityDto>
{
    public MetricsController(
        IMetricsService service, 
        IMapper mapper) : base(service, mapper)
    {
    }
    
}