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

[Route("api/trail-type")]
public class TrailTypeController : AbstractCrudController<
    TrailTypeDto, CreateTrailTypeDto, UpdateTrailTypeDto, 
    TrailTypeEntityDto, CreateTrailTypeEntityDto, UpdateTrailTypeEntityDto>
{
    public TrailTypeController(
        ITrailTypeService service, 
        IMapper mapper) : base(service, mapper)
    {
    }
    
}