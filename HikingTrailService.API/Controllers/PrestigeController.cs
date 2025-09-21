using AutoMapper;
using Common.API.Controllers;
using Common.Domain.Exceptions;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Delete;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.DTOs;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Delete;
using HikingTrailService.DTOs.Update;
using Microsoft.AspNetCore.Mvc;

namespace HikingTrailService.Controllers;

[Route("api/[controller]")]
public class PrestigeController : AbstractCrudController<PrestigeDto, CreatePrestigeDto, UpdatePrestigeDto, 
    PrestigeEntityDto, CreatePrestigeEntityDto, UpdatePrestigeEntityDto>
{
    private readonly IPrestigeService _prestigeService;
    
    public PrestigeController(
        IPrestigeService service, 
        IMapper mapper) : base(service, mapper)
    {
        _prestigeService = service;
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteByAccountAndHikingTrail(DeletePrestigeDto deletePrestigeDto)
    {
        try
        {
            await _prestigeService.DeleteByAccountAndHikingTrail(
                Mapper.Map<DeletePrestigeEntityDto>(deletePrestigeDto));
            
            return NoContent();
        }
        catch (NotFoundEntityException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}