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

[Route("api/health-metrics")]
public class HealthMetricsController : AbstractController<
    HealthMetricsDto, CreateHealthMetricsDto, UpdateHealthMetricsDto, 
    HealthMetricsEntityDto, CreateHealthMetricsEntityDto, UpdateHealthMetricsEntityDto>
{
    public HealthMetricsController(
        IHealthMetricsService healthMetricsService, 
        IMapper mapper) : base(healthMetricsService, mapper)
    {
    }
    
}