using AutoMapper;
using Common.API.Controllers;
using Common.Application.Interfaces;
using Common.Application.Pagination;
using Common.Domain.Exceptions;
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
public class HikingTrailController : AbstractCrudController<
    HikingTrailDto, CreateHikingTrailDto, UpdateHikingTrailDto, 
    HikingTrailEntityDto, CreateHikingTrailEntityDto, UpdateHikingTrailEntityDto>
{
    private readonly IHikingTrailService _hikingTrailService;
    private readonly ITokenManager _tokenManager;
    
    public HikingTrailController(
        IHikingTrailService hikingTrailHikingTrailService,
        ITokenManager tokenManager,
        IMapper mapper) : base(hikingTrailHikingTrailService, mapper)
    {
        _hikingTrailService = hikingTrailHikingTrailService;
        _tokenManager = tokenManager;
    }

    [HttpPost("account-codes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Page<HikingTrailDto>>> GetByAccountCodesPaged(
        HikingTrailFilterDto filterDto, 
        CancellationToken cancellationToken)
    {
        HikingTrailFilterEntityDto filterEntityDto = Mapper.Map<HikingTrailFilterEntityDto>(filterDto);
        
        Page<HikingTrailEntityDto> page = await _hikingTrailService
            .GetByAccountCodesPaged(filterEntityDto, cancellationToken);
        
        return Ok(Mapper.Map<Page<HikingTrailDto>>(page));
    }
    
    [HttpGet("searcher")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<IEnumerable<HikingTrailDto>>> Searcher(
        [FromQuery] string search,
        [FromQuery] int numberResults)
    {
        if (string.IsNullOrWhiteSpace(search))
            return BadRequest("search is empty");

        IEnumerable<HikingTrailEntityDto> result = await _hikingTrailService.SearcherAsync(search, numberResults);

        return Ok(Mapper.Map<IEnumerable<HikingTrailDto>>(result));
    }
    
    [HttpDelete("{code:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<ActionResult> Delete(Guid code)
    {
        try
        {
            string? ownerAccountCode = _tokenManager.GetUserCodeFromJwt(GetAccessToken());

            if (string.IsNullOrEmpty(ownerAccountCode))
                throw new UnauthorizedAccessException("The user code has not been found");
            
            await _hikingTrailService.LogicalDeleteAsync(new Guid(ownerAccountCode), code);
            
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