using AutoMapper;
using Common.Application.Interfaces;
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
    private readonly ITokenManager _tokenManager;

    public ActivityFilesController(
        ActivityFileProcessorFactory factory, 
        IMapper mapper,
        ITokenManager tokenManager)
    {
        _factory = factory;
        _mapper = mapper;
        _tokenManager = tokenManager;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadActivityFile([FromForm] ActivityFileUploadDto? uploadDto)
    {
        if (uploadDto?.ActivityFile is null || uploadDto.ActivityFile.Length == 0)
            return BadRequest("Invalid file");

        Request.Headers.TryGetValue("Authorization", out var token);
        
        if (token.Count == 0 || string.IsNullOrEmpty(token[0]))
            return Unauthorized();
        
        _tokenManager
            .GetPayloadFromJwt(token[0]!.Substring("Bearer ".Length).Trim())
            .TryGetValue("userCode", out var userCode);
        
        if (userCode is null)
            return Unauthorized();
        
        string extension = Path.GetExtension(uploadDto.ActivityFile.FileName).ToLowerInvariant();
        IActivityFileProcessor? fileProcessor = _factory.GetProcessor(extension);
        
        if (fileProcessor is null)
            return BadRequest("Invalid file extension");
        
        ActivityFileEntityDto entityDto = _mapper.Map<ActivityFileEntityDto>(uploadDto);
        
        entityDto.UserCode = userCode.ToString()!;
        
        await fileProcessor.ProcessAsync(entityDto);
        
        return Ok();
    }
    
}