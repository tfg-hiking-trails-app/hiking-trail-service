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

public class HikingTrailService : AbstractService<HikingTrail, HikingTrailEntityDto, CreateHikingTrailEntityDto, 
    UpdateHikingTrailEntityDto>, IHikingTrailService
{
    public HikingTrailService(
        IHikingTrailRepository repository, 
        IMapper mapper) 
        : base(repository, mapper)
    {
    }

    protected override void CheckDataValidity(CreateHikingTrailEntityDto createEntityDto)
    {
        Validator.CheckNullArgument(createEntityDto.Name, nameof(createEntityDto.Name));
    }
    
}