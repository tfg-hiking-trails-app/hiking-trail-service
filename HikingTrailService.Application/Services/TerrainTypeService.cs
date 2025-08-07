using AutoMapper;
using Common.Application.Services;
using Common.Application.Utils;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Application.Services;

public class TerrainTypeService : AbstractService<TerrainType, TerrainTypeEntityDto, CreateTerrainTypeEntityDto, 
    UpdateTerrainTypeEntityDto>, ITerrainTypeService
{
    public TerrainTypeService(
        ITerrainTypeRepository repository, 
        IMapper mapper) : base(repository, mapper)
    {
    }

    protected override void CheckDataValidity(CreateTerrainTypeEntityDto createEntityDto)
    {
        Validator.CheckNullArgument(createEntityDto.Terrain, nameof(createEntityDto.Terrain));
    }
    
}