using AutoMapper;
using Common.API.Extensions;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.Interfaces.Processors;
using HikingTrailService.Application.Services.Processors;
using HikingTrailService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HikingTrailService.Controllers;

[ApiController]
[Route("api/activity-files")]
[Produces("application/json")]
public class ActivityFilesController : ControllerBase
{
    private readonly ActivityFileProcessorFactory _factory;
    private readonly IMapper _mapper;

    public ActivityFilesController(
        ActivityFileProcessorFactory factory, 
        IMapper mapper)
    {
        _factory = factory;
        _mapper = mapper;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadActivityFile([FromForm] ActivityFileUploadDto? uploadDto)
    {
        if (uploadDto?.ActivityFile is null || uploadDto.ActivityFile.Length == 0)
            return BadRequest("Invalid file");
        
        string? userCode = Request.GetUserCode();
        
        if (userCode is null)
            return Unauthorized();
        
        string extension = Path.GetExtension(uploadDto.ActivityFile.FileName).ToLowerInvariant();
        IActivityFileProcessor? fileProcessor = _factory.GetProcessor(extension);
        
        if (fileProcessor is null)
            return BadRequest("Invalid file extension");
        
        ActivityFileEntityDto entityDto = _mapper.Map<ActivityFileEntityDto>(uploadDto);
        
        entityDto.UserCode = userCode;
        
        await fileProcessor.ProcessAsync(entityDto);
        
        return Ok();
    }
    
}