using AutoMapper;
using Common.API.Controllers;
using Common.Domain.Exceptions;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.DTOs;
using HikingTrailService.DTOs.Update;
using Microsoft.AspNetCore.Mvc;

namespace HikingTrailService.Controllers;

[Route("api/metrics-score")]
public class MetricsScoreController : AbstractReadController<MetricsScoreDto, MetricsScoreEntityDto, CreateMetricsScoreEntityDto, UpdateMetricsScoreEntityDto>
{
    private readonly IMetricsScoreService _metricsScoreService;
    
    public MetricsScoreController(
        IMetricsScoreService metricsScoreService, 
        IMapper mapper) : base(metricsScoreService, mapper)
    {
        _metricsScoreService = metricsScoreService;
    }

    [HttpGet("account/{accountCode:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<MetricsScoreDto>> GetByAccountCode(Guid accountCode)
    {
        try
        {
            MetricsScoreEntityDto entityDto = await _metricsScoreService.GetByAccountCodeAsync(accountCode);

            return Ok(Mapper.Map<MetricsScoreDto>(entityDto));
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

    [HttpPut("account")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<MetricsScoreDto>> Upsert([FromBody] UpdateMetricsScoreDto updateDto)
    {
        try
        {
            UpdateMetricsScoreEntityDto updateEntityDto = Mapper.Map<UpdateMetricsScoreEntityDto>(updateDto);

            return Ok(await _metricsScoreService.UpsertByAccountCodeAsync(updateEntityDto));
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