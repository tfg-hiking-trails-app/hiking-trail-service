using AutoMapper;
using Common.Application.Services;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Application.Services;

public class DifficultyLevelService : AbstractService<DifficultyLevel, DifficultyLevelEntityDto, 
        CreateDifficultyLevelEntityDto, UpdateDifficultyLevelEntityDto>, IDifficultyLevelService
{
    public DifficultyLevelService(
        IDifficultyLevelRepository hikingTrailRepository,
        IMapper mapper) 
        : base(hikingTrailRepository, mapper)
    {
    }

    protected override void CheckDataValidity(CreateDifficultyLevelEntityDto createEntityDto)
    {
        if (string.IsNullOrEmpty(createEntityDto.DifficultyLevelValue))
            throw new ArgumentNullException(nameof(createEntityDto.DifficultyLevelValue));
    }
    
}