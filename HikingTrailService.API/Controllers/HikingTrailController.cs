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

[Route("api/hiking-trail")]
public class HikingTrailController : AbstractController<
    HikingTrailDto, CreateHikingTrailDto, UpdateHikingTrailDto, 
    HikingTrailEntityDto, CreateHikingTrailEntityDto, UpdateHikingTrailEntityDto>
{
    public HikingTrailController(
        IHikingTrailService hikingTrailService,
        IMapper mapper) : base(hikingTrailService, mapper)
    {
    }
}