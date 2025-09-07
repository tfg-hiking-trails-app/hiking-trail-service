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

[Route("api/difficulty-level")]
public class DifficultyLevelController : AbstractCrudController<
    DifficultyLevelDto, CreateDifficultyLevelDto, UpdateDifficultyLevelDto, 
    DifficultyLevelEntityDto, CreateDifficultyLevelEntityDto, UpdateDifficultyLevelEntityDto>
{
    public DifficultyLevelController(
        IDifficultyLevelService difficultyLevelService, 
        IMapper mapper) : base(difficultyLevelService, mapper)
    {
    }
    
}