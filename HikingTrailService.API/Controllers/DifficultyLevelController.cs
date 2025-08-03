using AutoMapper;
using Common.API.DTOs.Filter;
using Common.API.Utils;
using Common.Application.DTOs.Filter;
using Common.Application.Pagination;
using Common.Domain.Exceptions;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.DTOs;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Update;
using Microsoft.AspNetCore.Mvc;

namespace HikingTrailService.Controllers;

[ApiController]
[Route("api/difficulty-level")]
[Produces("application/json")]
public class DifficultyLevelController : ControllerBase
{
    private readonly IDifficultyLevelService  _difficultyLevelService;
    private readonly IMapper _mapper;

    public DifficultyLevelController(
        IDifficultyLevelService difficultyLevelService, 
        IMapper mapper)
    {
        _difficultyLevelService = difficultyLevelService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Page<DifficultyLevelDto>>> Get(
        CancellationToken cancellationToken,
        [FromQuery] int pageNumber = Pagination.PageNumber,
        [FromQuery] int pageSize = Pagination.PageSize,
        [FromQuery] string sortField = Pagination.SortField,
        [FromQuery] string sortDirection = Pagination.SortDirection)
    {
        FilterDto filter = new FilterDto(pageNumber, pageSize, sortField, sortDirection);
        
        Page<DifficultyLevelEntityDto> page = await _difficultyLevelService
            .GetPagedAsync(_mapper.Map<FilterEntityDto>(filter), cancellationToken);
        
        return Ok(_mapper.Map<Page<DifficultyLevelDto>>(page));
    }

    [HttpGet("{code}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DifficultyLevelDto>> GetByCode(string code)
    {
        try
        {
            DifficultyLevelEntityDto entityDto = await _difficultyLevelService.GetByCodeAsync(Guid.Parse(code));

            return Ok(_mapper.Map<DifficultyLevelDto>(entityDto));
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
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DifficultyLevelDto>> Post([FromBody] CreateDifficultyLevelDto createDto)
    {
        try
        {
            CreateDifficultyLevelEntityDto createEntityDto = _mapper.Map<CreateDifficultyLevelEntityDto>(createDto);
        
            Guid code = await _difficultyLevelService.CreateAsync(createEntityDto);

            return Created();
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
    
    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DifficultyLevelDto>> Patch([FromBody] UpdateDifficultyLevelDto updateDto)
    {
        try
        {
            UpdateDifficultyLevelEntityDto updateEntityDto = _mapper.Map<UpdateDifficultyLevelEntityDto>(updateDto);

            Guid code = await _difficultyLevelService.UpdateAsync(updateDto.Code, updateEntityDto);

            return Ok(code);
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
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete([FromBody] string code)
    {
        try
        {
            await _difficultyLevelService.DeleteAsync(Guid.Parse(code));
            
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