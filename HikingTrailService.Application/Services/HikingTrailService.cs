using AutoMapper;
using Common.Application.Pagination;
using Common.Application.Services;
using Common.Application.Utils;
using Common.Domain.Exceptions;
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
    private readonly IDifficultyLevelRepository _difficultyLevelRepository;
    private readonly ITerrainTypeRepository _terrainTypeRepository;
    private readonly ITrailTypeRepository _trailTypeRepository;
    private readonly IMetricsRepository _metricsRepository;
    private readonly ILocationService _locationService;
    
    public HikingTrailService(
        IHikingTrailRepository hikingTrailRepository,
        IDifficultyLevelRepository difficultyLevelRepository,
        ITerrainTypeRepository terrainTypeRepository,
        ITrailTypeRepository trailTypeRepository,
        IMetricsRepository metricsRepository,
        ILocationService locationService,
        IMapper mapper) 
        : base(hikingTrailRepository, mapper)
    {
        _hikingTrailRepository = hikingTrailRepository;
        _difficultyLevelRepository = difficultyLevelRepository;
        _terrainTypeRepository = terrainTypeRepository;
        _trailTypeRepository = trailTypeRepository;
        _metricsRepository = metricsRepository;
        _locationService = locationService;
    }

    protected override void CheckDataValidity(CreateHikingTrailEntityDto createEntityDto)
    {
        Validator.CheckNullArgument(createEntityDto.Name, nameof(createEntityDto.Name));
        Validator.CheckNullArgument(createEntityDto.Metrics, nameof(createEntityDto.Metrics));
        Validator.CheckNullArgument(createEntityDto.StartTime, nameof(createEntityDto.StartTime));
        Validator.CheckNullArgument(createEntityDto.EndTime, nameof(createEntityDto.EndTime));
        Validator.CheckNullArgument(createEntityDto.Metrics, nameof(createEntityDto.Metrics));
        Validator.CheckPositiveValue(createEntityDto.Metrics!.Distance, nameof(createEntityDto.Metrics.Distance));
        
        if (createEntityDto.DifficultyLevelCode.HasValue)
            Validator.CheckGuid(createEntityDto.DifficultyLevelCode.Value);
        if (createEntityDto.TerrainTypeCode.HasValue)
            Validator.CheckGuid(createEntityDto.TerrainTypeCode.Value);
        if (createEntityDto.TrailTypeCode.HasValue)
            Validator.CheckGuid(createEntityDto.TrailTypeCode.Value);
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

    public override async Task<Guid> CreateAsync(CreateHikingTrailEntityDto createEntityDto)
    {
        CheckDataValidity(createEntityDto);

        DifficultyLevel? difficultyLevel = null;
        TerrainType? terrainType = null;
        TrailType? trailType = null;
        HikingTrail hikingTrailEntity = Mapper.Map<HikingTrail>(createEntityDto);

        if (createEntityDto.DifficultyLevelCode.HasValue)
            difficultyLevel = await _difficultyLevelRepository.GetByCodeAsync(createEntityDto.DifficultyLevelCode.Value);
        if (createEntityDto.TerrainTypeCode.HasValue)
            terrainType = await _terrainTypeRepository.GetByCodeAsync(createEntityDto.TerrainTypeCode.Value);
        if (createEntityDto.TrailTypeCode.HasValue)
            trailType = await _trailTypeRepository.GetByCodeAsync(createEntityDto.TrailTypeCode.Value);

        if (difficultyLevel is not null)
            hikingTrailEntity.DifficultyLevelId = difficultyLevel.Id;
        if (terrainType is not null)
            hikingTrailEntity.TerrainTypeId = terrainType.Id;
        if (trailType is not null)
            hikingTrailEntity.TrailTypeId = trailType.Id;
        if (hikingTrailEntity.Code == Guid.Empty)
            hikingTrailEntity.Code = Guid.NewGuid();

        int hikingTrailId = await _hikingTrailRepository.AddAsync(hikingTrailEntity);
        
        Metrics metrics = Mapper.Map<Metrics>(createEntityDto.Metrics);
        
        metrics.HikingTrailId = hikingTrailId;
        
        await _metricsRepository.AddAsync(metrics);

        if (createEntityDto.LocationLatitude.HasValue && createEntityDto.LocationLongitude.HasValue)
            await _locationService.CreateAsync(
                hikingTrailEntity.Code, 
                createEntityDto.LocationLatitude.Value, 
                createEntityDto.LocationLongitude.Value);

        return hikingTrailEntity.Code;
    }
    
    public override async Task<Guid> UpdateAsync(Guid code, UpdateHikingTrailEntityDto updateEntityDto)
    {
        HikingTrail entity = await GetEntity(code);

        if (entity.DifficultyLevel?.Code != updateEntityDto.DifficultyLevelCode)
        {
            entity.DifficultyLevel = !updateEntityDto.DifficultyLevelCode.HasValue 
                ? null 
                : await _difficultyLevelRepository.GetByCodeAsync(updateEntityDto.DifficultyLevelCode.Value);
        }
        
        if (entity.TerrainType?.Code != updateEntityDto.TerrainTypeCode)
        {
            entity.TerrainType = !updateEntityDto.TerrainTypeCode.HasValue 
                ? null 
                : await _terrainTypeRepository.GetByCodeAsync(updateEntityDto.TerrainTypeCode.Value);
        }
        
        if (entity.TrailType?.Code != updateEntityDto.TrailTypeCode)
        {
            entity.TrailType = !updateEntityDto.TrailTypeCode.HasValue 
                ? null 
                : await _trailTypeRepository.GetByCodeAsync(updateEntityDto.TrailTypeCode.Value);
        }
        
        Mapper.Map(updateEntityDto, entity);
        
        await Repository.UpdateAsync(entity);
        
        return entity.Code;
    }
    
    public async Task LogicalDeleteAsync(Guid ownerAccountCode, Guid hikingTrailCode)
    {
        HikingTrail? hikingTrail = await _hikingTrailRepository.GetByCodeAsync(hikingTrailCode);

        if (hikingTrail is null)
            throw new NotFoundEntityException(nameof(HikingTrail), hikingTrailCode);
        
        if (hikingTrail.AccountCode != ownerAccountCode)
            throw new UnauthorizedAccessException("The hiking trail does not belong to the user");

        hikingTrail.Deleted = true;
        
        await _hikingTrailRepository.SaveChangesAsync();
    }
    
}