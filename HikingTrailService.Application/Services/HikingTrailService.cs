using AutoMapper;
using Common.Application.Pagination;
using Common.Application.Services;
using Common.Application.Utils;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Filter;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Application.Services;

public class HikingTrailService : AbstractService<HikingTrail, HikingTrailEntityDto, CreateHikingTrailEntityDto, 
    UpdateHikingTrailEntityDto>, IHikingTrailService
{
    private readonly IHikingTrailRepository _repository;
    
    public HikingTrailService(
        IHikingTrailRepository repository, 
        IMapper mapper) 
        : base(repository, mapper)
    {
        _repository = repository;
    }

    protected override void CheckDataValidity(CreateHikingTrailEntityDto createEntityDto)
    {
        Validator.CheckNullArgument(createEntityDto.Name, nameof(createEntityDto.Name));
    }

    public async Task<Page<HikingTrailEntityDto>> GetByAccountCodesPaged(HikingTrailFilterEntityDto filterEntityDto, CancellationToken cancellationToken)
    {
        FilterData filterData = Mapper.Map<FilterData>(filterEntityDto.Filter);
        
        IPaged<HikingTrail> result = await _repository.GetByAccountCodesPaged(filterEntityDto.AccountCodes, filterData, cancellationToken);
        
        return Mapper.Map<Page<HikingTrailEntityDto>>(result);
    }
}