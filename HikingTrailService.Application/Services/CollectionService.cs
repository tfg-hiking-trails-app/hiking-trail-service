using AutoMapper;
using Common.Application.DTOs.Filter;
using Common.Application.Pagination;
using Common.Application.Services;
using Common.Application.Utils;
using Common.Domain.Exceptions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Application.Services;

public class CollectionService : AbstractService<Collection, CollectionEntityDto, CreateCollectionEntityDto,
    UpdateCollectionEntityDto>, ICollectionService
{
    private const string DefaultCollectionName = "Favoritos";

    private readonly ICollectionRepository _collectionRepository;
    private readonly ICollectionTrailRepository _collectionTrailRepository;
    private readonly IHikingTrailRepository _hikingTrailRepository;

    public CollectionService(
        ICollectionRepository collectionRepository,
        ICollectionTrailRepository collectionTrailRepository,
        IHikingTrailRepository hikingTrailRepository,
        IMapper mapper) : base(collectionRepository, mapper)
    {
        _collectionRepository = collectionRepository;
        _collectionTrailRepository = collectionTrailRepository;
        _hikingTrailRepository = hikingTrailRepository;
    }

    public override async Task<Guid> CreateAsync(CreateCollectionEntityDto createEntityDto)
    {
        CheckDataValidity(createEntityDto);

        string name = createEntityDto.Name.Trim();

        if (await _collectionRepository.ExistsByAccountCodeAndNameAsync(createEntityDto.AccountCode, name))
            throw new EntityAlreadyExistsException("A collection with this name already exists");

        Collection collection = new Collection
        {
            Code = Guid.NewGuid(),
            AccountCode = createEntityDto.AccountCode,
            Name = name,
            IsDefault = false
        };

        await _collectionRepository.AddAsync(collection);

        return collection.Code;
    }

    public async Task<IEnumerable<CollectionEntityDto>> GetByAccountCodeAsync(Guid accountCode)
    {
        await EnsureDefaultCollectionAsync(accountCode);

        IEnumerable<Collection> collections = await _collectionRepository.GetByAccountCodeAsync(accountCode);

        return Mapper.Map<IEnumerable<CollectionEntityDto>>(collections);
    }

    public async Task<CollectionEntityDto> GetByCodeForAccountAsync(Guid code, Guid accountCode)
    {
        Collection collection = await GetOwnedCollectionAsync(code, accountCode);

        return Mapper.Map<CollectionEntityDto>(collection);
    }

    public async Task<Guid> RenameAsync(Guid code, Guid accountCode, string name)
    {
        Collection collection = await GetOwnedCollectionAsync(code, accountCode);

        if (collection.IsDefault)
            throw new InvalidOperationException("The Favorites collection cannot be modified");

        string newName = (name ?? string.Empty).Trim();

        if (string.IsNullOrEmpty(newName))
            throw new ArgumentException("The collection name is required");

        if (!string.Equals(collection.Name, newName, StringComparison.OrdinalIgnoreCase)
            && await _collectionRepository.ExistsByAccountCodeAndNameAsync(accountCode, newName))
            throw new EntityAlreadyExistsException("A collection with this name already exists");

        collection.Name = newName;

        await _collectionRepository.UpdateAsync(collection);

        return collection.Code;
    }

    public async Task RemoveCollectionAsync(Guid code, Guid accountCode)
    {
        Collection collection = await GetOwnedCollectionAsync(code, accountCode);

        if (collection.IsDefault)
            throw new InvalidOperationException("The Favorites collection cannot be deleted");

        await _collectionRepository.DeleteAsync(collection);
    }

    public async Task<Page<HikingTrailEntityDto>> GetTrailsByCollectionPaged(
        Guid code,
        Guid accountCode,
        FilterEntityDto filter,
        CancellationToken cancellationToken)
    {
        Collection collection = await GetOwnedCollectionAsync(code, accountCode);

        IPaged<HikingTrail> result = await _collectionTrailRepository
            .GetTrailsByCollectionPaged(collection.Id, Mapper.Map<FilterData>(filter), cancellationToken);

        return Mapper.Map<Page<HikingTrailEntityDto>>(result);
    }

    public async Task AddTrailAsync(Guid collectionCode, Guid accountCode, Guid hikingTrailCode)
    {
        Collection collection = await GetOwnedCollectionAsync(collectionCode, accountCode);

        HikingTrail hikingTrail = await GetTrailAsync(hikingTrailCode);

        if (await _collectionTrailRepository.ExistsByCollectionAndTrailAsync(collection.Id, hikingTrail.Id))
            throw new EntityAlreadyExistsException("The trail is already in this collection");

        CollectionTrail collectionTrail = new CollectionTrail
        {
            Code = Guid.NewGuid(),
            CollectionId = collection.Id,
            HikingTrailId = hikingTrail.Id
        };

        await _collectionTrailRepository.AddAsync(collectionTrail);
    }

    public async Task RemoveTrailAsync(Guid collectionCode, Guid accountCode, Guid hikingTrailCode)
    {
        Collection collection = await GetOwnedCollectionAsync(collectionCode, accountCode);

        HikingTrail hikingTrail = await GetTrailAsync(hikingTrailCode);

        CollectionTrail? collectionTrail = await _collectionTrailRepository
            .GetByCollectionAndTrailAsync(collection.Id, hikingTrail.Id);

        if (collectionTrail is null)
            throw new NotFoundEntityException(nameof(CollectionTrail), hikingTrailCode);

        await _collectionTrailRepository.DeleteAsync(collectionTrail);
    }

    public Task<IEnumerable<Guid>> GetSavedTrailCodesAsync(Guid accountCode)
    {
        return _collectionTrailRepository.GetSavedTrailCodesByAccountAsync(accountCode);
    }

    protected override void CheckDataValidity(CreateCollectionEntityDto createEntityDto)
    {
        if (string.IsNullOrWhiteSpace(createEntityDto.Name))
            Validator.CheckNullArgument(createEntityDto.Name, nameof(createEntityDto.Name));

        Validator.CheckGuid(createEntityDto.AccountCode);
    }

    private async Task EnsureDefaultCollectionAsync(Guid accountCode)
    {
        if (accountCode == Guid.Empty)
            return;

        Collection? defaultCollection = await _collectionRepository.GetDefaultByAccountCodeAsync(accountCode);

        if (defaultCollection is not null)
            return;

        Collection collection = new Collection
        {
            Code = Guid.NewGuid(),
            AccountCode = accountCode,
            Name = DefaultCollectionName,
            IsDefault = true
        };

        await _collectionRepository.AddAsync(collection);
    }

    private async Task<Collection> GetOwnedCollectionAsync(Guid code, Guid accountCode)
    {
        Collection? collection = await _collectionRepository.GetByCodeAsync(code);

        if (collection is null)
            throw new NotFoundEntityException(nameof(Collection), code);

        if (collection.AccountCode != accountCode)
            throw new UnauthorizedAccessException("The collection does not belong to the user");

        return collection;
    }

    private async Task<HikingTrail> GetTrailAsync(Guid hikingTrailCode)
    {
        HikingTrail? hikingTrail = await _hikingTrailRepository.GetByCodeAsync(hikingTrailCode);

        if (hikingTrail is null)
            throw new NotFoundEntityException(nameof(HikingTrail), hikingTrailCode);

        return hikingTrail;
    }
}
