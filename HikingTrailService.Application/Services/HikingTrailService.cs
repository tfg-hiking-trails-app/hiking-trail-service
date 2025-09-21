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
    private readonly IHikingTrailRepository _hikingTrailRepository;
    
    public HikingTrailService(
        IHikingTrailRepository hikingTrailRepository, 
        IMapper mapper) 
        : base(hikingTrailRepository, mapper)
    {
        _hikingTrailRepository = hikingTrailRepository;
    }

    protected override void CheckDataValidity(CreateHikingTrailEntityDto createEntityDto)
    {
        Validator.CheckNullArgument(createEntityDto.Name, nameof(createEntityDto.Name));
    }

    public async Task<Page<HikingTrailEntityDto>> GetByAccountCodesPaged(HikingTrailFilterEntityDto filterEntityDto, CancellationToken cancellationToken)
    {
        FilterData filterData = Mapper.Map<FilterData>(filterEntityDto.Filter);
        
        IPaged<HikingTrail> result = await _hikingTrailRepository.GetByAccountCodesPaged(filterEntityDto.AccountCodes, filterData, cancellationToken);
        
        return Mapper.Map<Page<HikingTrailEntityDto>>(result);
    }

    public async Task<IEnumerable<HikingTrailEntityDto>> SearcherAsync(string search, int numberResults)
    {
        IEnumerable<HikingTrail> hikingTrails = await _hikingTrailRepository.SearcherAsync(search, numberResults);
        
        return Mapper.Map<IEnumerable<HikingTrailEntityDto>>(hikingTrails);
    }
    
}