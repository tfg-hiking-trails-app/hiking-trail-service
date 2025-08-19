using AutoMapper;
using Common.API.Controllers;
using Common.Application.Pagination;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Filter;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.DTOs;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Filter;
using HikingTrailService.DTOs.Update;
using Microsoft.AspNetCore.Mvc;

namespace HikingTrailService.Controllers;

[Route("api/hiking-trail")]
public class HikingTrailController : AbstractController<
    HikingTrailDto, CreateHikingTrailDto, UpdateHikingTrailDto, 
    HikingTrailEntityDto, CreateHikingTrailEntityDto, UpdateHikingTrailEntityDto>
{
    private readonly IHikingTrailService _service;
    
    public HikingTrailController(
        IHikingTrailService hikingTrailService,
        IMapper mapper) : base(hikingTrailService, mapper)
    {
        _service = hikingTrailService;
    }

    [HttpPost("account-codes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Page<HikingTrailDto>>> GetByAccountCodesPaged(
        HikingTrailFilterDto filterDto, 
        CancellationToken cancellationToken)
    {
        HikingTrailFilterEntityDto filterEntityDto = Mapper.Map<HikingTrailFilterEntityDto>(filterDto);
        
        Page<HikingTrailEntityDto> page = await _service
            .GetByAccountCodesPaged(filterEntityDto, cancellationToken);
        
        return Ok(Mapper.Map<Page<HikingTrailDto>>(page));
    }
    
}