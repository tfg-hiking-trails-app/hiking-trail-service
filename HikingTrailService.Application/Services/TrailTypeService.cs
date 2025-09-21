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

public class TrailTypeService : AbstractService<TrailType, TrailTypeEntityDto, CreateTrailTypeEntityDto, 
    UpdateTrailTypeEntityDto>, ITrailTypeService
{
    public TrailTypeService(
        ITrailTypeRepository hikingTrailRepository, 
        IMapper mapper) : base(hikingTrailRepository, mapper)
    {
    }

    protected override void CheckDataValidity(CreateTrailTypeEntityDto createEntityDto)
    {
        Validator.CheckNullArgument(createEntityDto.Trail, nameof(createEntityDto.Trail));
    }
    
}