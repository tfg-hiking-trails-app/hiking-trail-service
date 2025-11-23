using AutoMapper;
using Common.Application;
using Common.Application.DTOs.Filter;
using Common.Application.Interfaces;
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
using HikingTrailService.Domain.Recommender;

namespace HikingTrailService.Application.Services;

public class HikingTrailService : AbstractService<HikingTrail, HikingTrailEntityDto, CreateHikingTrailEntityDto, 
    UpdateHikingTrailEntityDto>, IHikingTrailService
{
    private readonly IHikingTrailRepository _hikingTrailRepository;
    private readonly IDifficultyLevelRepository _difficultyLevelRepository;
    private readonly ITerrainTypeRepository _terrainTypeRepository;
    private readonly ITrailTypeRepository _trailTypeRepository;
    private readonly IMetricsRepository _metricsRepository;
    private readonly IImagesRepository _imagesRepository;
    private readonly ILocationService _locationService;
    private readonly IUploadImageService _uploadImageService;
    private readonly IRecommenderService _recommenderService;
    
    public HikingTrailService(
        IHikingTrailRepository hikingTrailRepository,
        IDifficultyLevelRepository difficultyLevelRepository,
        ITerrainTypeRepository terrainTypeRepository,
        ITrailTypeRepository trailTypeRepository,
        IMetricsRepository metricsRepository,
        IImagesRepository imagesRepository,
        ILocationService locationService,
        IUploadImageService uploadImageService,
        IRecommenderService recommenderService,
        IMapper mapper) 
        : base(hikingTrailRepository, mapper)
    {
        _hikingTrailRepository = hikingTrailRepository;
        _difficultyLevelRepository = difficultyLevelRepository;
        _terrainTypeRepository = terrainTypeRepository;
        _trailTypeRepository = trailTypeRepository;
        _metricsRepository = metricsRepository;
        _imagesRepository = imagesRepository;
        _locationService = locationService;
        _uploadImageService = uploadImageService;
        _recommenderService = recommenderService;
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

    public async Task<Page<HikingTrailEntityDto>> GetNewestAsync(FilterEntityDto filterEntityDto, CancellationToken cancellationToken)
    {
        FilterData filterData = Mapper.Map<FilterData>(filterEntityDto);

        IPaged<HikingTrail> result = await _hikingTrailRepository.GetNewestAsync(filterData, cancellationToken);

        return Mapper.Map<Page<HikingTrailEntityDto>>(result);
    }

    public async Task<Page<HikingTrailEntityDto>> RecommenderAsync(RecommenderEntityDto recommenderEntityDto, FilterEntityDto filterEntityDto,
        CancellationToken cancellationToken)
    {
        RecommenderData recommenderData = Mapper.Map<RecommenderData>(recommenderEntityDto);
        FilterData filterData = Mapper.Map<FilterData>(filterEntityDto);
        
        IList<HikingTrail> hikingTrailsNearby = await _hikingTrailRepository.RecommenderAsync(recommenderData, filterData, cancellationToken);

        // Apply algorithm
        return await _recommenderService.RecommenderAsync(
            recommenderEntityDto.AccountCode, 
            Mapper.Map<List<HikingTrailEntityDto>>(hikingTrailsNearby), 
            filterEntityDto,
            cancellationToken);
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

        hikingTrailEntity.Id = await _hikingTrailRepository.AddAsync(hikingTrailEntity);
        
        await CreateMetricsAsync(createEntityDto, hikingTrailEntity);
        await CreateImagesAsync(createEntityDto.Images, hikingTrailEntity);
        await CreateLocationAsync(createEntityDto, hikingTrailEntity);
        
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

        await UpdateImagesAsync(updateEntityDto, entity);
        
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
    
    private async Task CreateMetricsAsync(CreateHikingTrailEntityDto createEntityDto, HikingTrail hikingTrail)
    {
        Metrics metrics = Mapper.Map<Metrics>(createEntityDto.Metrics);
        
        metrics.HikingTrailId = hikingTrail.Id;
        
        await _metricsRepository.AddAsync(metrics);
    }
    
    private async Task CreateImagesAsync(List<FileEntityDto> imageList, HikingTrail hikingTrail)
    {
        List<FileEntityDto> filter = imageList
            .Where(uploadImage => uploadImage.Content.Length > 0)
            .ToList();
        
        for (int i = 0; i < filter.Count; i++)
        {
            Images images = new Images()
            {
                Code = Guid.NewGuid(),
                HikingTrail = hikingTrail,
                ImageUrl = await _uploadImageService.UploadImage(filter[i]),
                OrderIndex = i
            };
            
            await _imagesRepository.AddAsync(images);
        }
    }
    
    private async Task CreateLocationAsync(CreateHikingTrailEntityDto createEntityDto, HikingTrail hikingTrail)
    {
        if (!createEntityDto.LocationLatitude.HasValue || !createEntityDto.LocationLongitude.HasValue)
            return;
        
        await _locationService.CreateAsync(
            hikingTrail.Code, 
            createEntityDto.LocationLatitude.Value, 
            createEntityDto.LocationLongitude.Value);
    }
    
    private async Task UpdateImagesAsync(UpdateHikingTrailEntityDto updateEntityDto, HikingTrail hikingTrail)
    {
        foreach (var deletedImage in updateEntityDto.DeletedImages)
        {
            Images? image = await _imagesRepository.GetByHikingTrailIdAndImageUrlAsync(hikingTrail.Id, deletedImage);
            
            if (image is not null)
                image.Deleted = true;
        }
        
        await _imagesRepository.SaveChangesAsync();
        
        await CreateImagesAsync(updateEntityDto.Images, hikingTrail);
    }
    
}