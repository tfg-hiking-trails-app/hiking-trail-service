using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;

namespace HikingTrailService.Application.Interfaces;

public interface IDifficultyLevelService : IService<
    DifficultyLevelEntityDto, 
    CreateDifficultyLevelEntityDto, 
    UpdateDifficultyLevelEntityDto>
{
}