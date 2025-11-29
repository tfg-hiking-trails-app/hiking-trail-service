using AutoMapper;
using Common.API.Controllers;
using Common.API.DTOs.Filter;
using Common.API.Utils;
using Common.Application.DTOs.Filter;
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
public class HikingTrailController : AbstractReadController<HikingTrailDto, HikingTrailEntityDto, 
    CreateHikingTrailEntityDto, UpdateHikingTrailEntityDto>
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
    
    [HttpGet("newest")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<IEnumerable<HikingTrailDto>>> Newest(
        CancellationToken cancellationToken,
        [FromQuery] int pageNumber = Pagination.PageNumber,
        [FromQuery] int pageSize = Pagination.PageSize,
        [FromQuery] string sortField = Pagination.SortField,
        [FromQuery] string sortDirection = Pagination.SortDirection)
    {
        FilterEntityDto filter = Mapper.Map<FilterEntityDto>
            (new FilterDto(pageNumber, pageSize, sortField, sortDirection));

        Page<HikingTrailEntityDto> page = await _hikingTrailService.GetNewestAsync(filter, cancellationToken);

        return Ok(Mapper.Map<Page<HikingTrailDto>>(page));
    }

    [HttpPost("recommender")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<IEnumerable<HikingTrailDto>>> Recommender(
        RecommenderDto recommenderDto,
        CancellationToken cancellationToken,
        [FromQuery] int pageNumber = Pagination.PageNumber,
        [FromQuery] int pageSize = Pagination.PageSize,
        [FromQuery] string sortField = Pagination.SortField,
        [FromQuery] string sortDirection = Pagination.SortDirection)
    {
        FilterEntityDto filter = Mapper.Map<FilterEntityDto>
            (new FilterDto(pageNumber, pageSize, sortField, sortDirection));
        
        Page<HikingTrailEntityDto> page = await _hikingTrailService.RecommenderAsync(
            Mapper.Map<RecommenderEntityDto>(recommenderDto), 
            filter, 
            cancellationToken);

        return Ok(Mapper.Map<Page<HikingTrailDto>>(page));
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HikingTrailDto>> Create([FromForm] CreateHikingTrailDto createDto)
    {
        try
        {
            CreateHikingTrailEntityDto createEntityDto = Mapper.Map<CreateHikingTrailEntityDto>(createDto);
        
            Guid code = await _hikingTrailService.CreateAsync(createEntityDto);

            HikingTrailEntityDto entityDto = await _hikingTrailService.GetByCodeAsync(code);
            
            HikingTrailDto dto = Mapper.Map<HikingTrailDto>(entityDto);
            
            string actionName = nameof(GetByCode);
            
            return CreatedAtAction(actionName, new { code }, dto);
        }
        catch (EntityAlreadyExistsException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut("{code:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<HikingTrailDto>> Update(Guid code, [FromForm] UpdateHikingTrailDto updateDto)
    {
        try
        {
            UpdateHikingTrailEntityDto updateEntityDto = Mapper.Map<UpdateHikingTrailEntityDto>(updateDto);

            return Ok(await _hikingTrailService.UpdateAsync(code, updateEntityDto));
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
    
    [HttpDelete("{code:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(Guid code)
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