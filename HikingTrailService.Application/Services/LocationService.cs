using AutoMapper;
using Common.Application.Services;
using Common.Application.Utils;
using Common.Domain.Exceptions;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Application.Services;

public class LocationService : AbstractService<Location, LocationEntityDto, CreateLocationEntityDto, 
    UpdateLocationEntityDto>, ILocationService
{
    private readonly IGeoapifyGeocoding  _geoapifyGeocoding;
    private readonly IHikingTrailRepository _hikingTrailRepository;
    
    public LocationService(
        ILocationRepository locationHikingTrailRepository, 
        IMapper mapper,
        IGeoapifyGeocoding geoapifyGeocoding,
        IHikingTrailRepository hikingTrailRepository) : base(locationHikingTrailRepository, mapper)
    {
        _geoapifyGeocoding = geoapifyGeocoding;
        _hikingTrailRepository = hikingTrailRepository;
    }
    
    public virtual async Task<Guid> CreateAsync(Guid hikingTrailCode, double latitude, double longitude)
    {
        LocationEntityDto? locationEntityDto = await _geoapifyGeocoding.ReverseGeocodingAsync(latitude, longitude);
        
        if (locationEntityDto is null)
            return Guid.Empty;
        
        HikingTrail? hikingTrail = await _hikingTrailRepository.GetByCodeAsync(hikingTrailCode);
        
        if (hikingTrail is null)
            throw new NotFoundEntityException(nameof(HikingTrail), hikingTrailCode);
        
        Location entity = Mapper.Map<Location>(locationEntityDto);
        
        entity.HikingTrailId = hikingTrail.Id;
        
        if (entity.Code == Guid.Empty)
            entity.Code = Guid.NewGuid();

        await Repository.AddAsync(entity);

        return entity.Code;
    }

    protected override void CheckDataValidity(CreateLocationEntityDto createEntityDto)
    {
        Validator.CheckNullArgument(createEntityDto.Country, nameof(createEntityDto.Country));
        Validator.CheckNullArgument(createEntityDto.CountryCode, nameof(createEntityDto.CountryCode));
    }
    
}