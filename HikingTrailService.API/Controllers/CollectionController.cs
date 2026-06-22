using AutoMapper;
using Common.API.DTOs.Filter;
using Common.API.Extensions;
using Common.API.Utils;
using Common.Application.DTOs.Filter;
using Common.Application.Pagination;
using Common.Domain.Exceptions;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.DTOs;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Update;
using Microsoft.AspNetCore.Mvc;

namespace HikingTrailService.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/collection")]
public class CollectionController : ControllerBase
{
    private readonly ICollectionService _service;
    private readonly IMapper _mapper;

    public CollectionController(
        ICollectionService service,
        IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("logged")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CollectionDto>>> GetLogged()
    {
        try
        {
            Guid? userCode = GetUserCode();

            if (userCode is null)
                return Unauthorized();

            IEnumerable<CollectionEntityDto> collections = await _service.GetByAccountCodeAsync(userCode.Value);

            return Ok(_mapper.Map<IEnumerable<CollectionDto>>(collections));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{code:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CollectionDto>> GetByCode(Guid code)
    {
        try
        {
            Guid? userCode = GetUserCode();

            if (userCode is null)
                return Unauthorized();

            CollectionEntityDto collection = await _service.GetByCodeForAccountAsync(code, userCode.Value);

            return Ok(_mapper.Map<CollectionDto>(collection));
        }
        catch (NotFoundEntityException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{code:guid}/trails")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Page<HikingTrailDto>>> GetTrails(
        Guid code,
        CancellationToken cancellationToken,
        [FromQuery] int pageNumber = Pagination.PageNumber,
        [FromQuery] int pageSize = Pagination.PageSize,
        [FromQuery] string sortField = Pagination.SortField,
        [FromQuery] string sortDirection = Pagination.SortDirection)
    {
        try
        {
            Guid? userCode = GetUserCode();

            if (userCode is null)
                return Unauthorized();

            FilterDto filter = new FilterDto(pageNumber, pageSize, sortField, sortDirection);

            Page<HikingTrailEntityDto> page = await _service.GetTrailsByCollectionPaged(
                code, userCode.Value, _mapper.Map<FilterEntityDto>(filter), cancellationToken);

            return Ok(_mapper.Map<Page<HikingTrailDto>>(page));
        }
        catch (NotFoundEntityException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
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
    public async Task<ActionResult<CollectionDto>> Create([FromBody] CreateCollectionDto createDto)
    {
        try
        {
            Guid? userCode = GetUserCode();

            if (userCode is null)
                return Unauthorized();

            CreateCollectionEntityDto createEntityDto = _mapper.Map<CreateCollectionEntityDto>(createDto);
            createEntityDto.AccountCode = userCode.Value;

            Guid code = await _service.CreateAsync(createEntityDto);

            CollectionEntityDto entityDto = await _service.GetByCodeForAccountAsync(code, userCode.Value);

            CollectionDto dto = _mapper.Map<CollectionDto>(entityDto);

            return CreatedAtAction(nameof(GetByCode), new { code }, dto);
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
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Update(Guid code, [FromBody] UpdateCollectionDto updateDto)
    {
        try
        {
            Guid? userCode = GetUserCode();

            if (userCode is null)
                return Unauthorized();

            return Ok(await _service.RenameAsync(code, userCode.Value, updateDto.Name));
        }
        catch (NotFoundEntityException ex)
        {
            return NotFound(ex.Message);
        }
        catch (EntityAlreadyExistsException ex)
        {
            return Conflict(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{code:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(Guid code)
    {
        try
        {
            Guid? userCode = GetUserCode();

            if (userCode is null)
                return Unauthorized();

            await _service.RemoveCollectionAsync(code, userCode.Value);

            return NoContent();
        }
        catch (NotFoundEntityException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{code:guid}/trails")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddTrail(Guid code, [FromBody] AddTrailToCollectionDto addTrailDto)
    {
        try
        {
            Guid? userCode = GetUserCode();

            if (userCode is null)
                return Unauthorized();

            await _service.AddTrailAsync(code, userCode.Value, addTrailDto.HikingTrailCode!.Value);

            return NoContent();
        }
        catch (NotFoundEntityException ex)
        {
            return NotFound(ex.Message);
        }
        catch (EntityAlreadyExistsException ex)
        {
            return Conflict(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{code:guid}/trails/{trailCode:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> RemoveTrail(Guid code, Guid trailCode)
    {
        try
        {
            Guid? userCode = GetUserCode();

            if (userCode is null)
                return Unauthorized();

            await _service.RemoveTrailAsync(code, userCode.Value, trailCode);

            return NoContent();
        }
        catch (NotFoundEntityException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    private Guid? GetUserCode()
    {
        string? userCode = Request.GetUserCode();

        return Guid.TryParse(userCode, out Guid parsed)
            ? parsed
            : null;
    }
}
