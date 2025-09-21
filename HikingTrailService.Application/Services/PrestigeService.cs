using AutoMapper;
using Common.Application.Services;
using Common.Application.Utils;
using Common.Domain.Exceptions;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Delete;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Application.Services;

public class PrestigeService : AbstractService<Prestige, PrestigeEntityDto, CreatePrestigeEntityDto, 
    UpdatePrestigeEntityDto>, IPrestigeService
{
    private readonly IPrestigeRepository _prestigeRepository;
    private readonly IHikingTrailRepository _hikingTrailRepository;
    
    public PrestigeService(
        IPrestigeRepository repository, 
        IHikingTrailRepository hikingTrailRepository,
        IMapper mapper) : base(repository, mapper)
    {
        _prestigeRepository = repository;
        _hikingTrailRepository = hikingTrailRepository;
    }
    
    public override async Task<Guid> CreateAsync(CreatePrestigeEntityDto createEntityDto)
    {
        CheckDataValidity(createEntityDto);
        
        Prestige prestige = Mapper.Map<Prestige>(createEntityDto);
        
        HikingTrail? hikingTrail = await _hikingTrailRepository.GetByCodeAsync(createEntityDto.HikingTrailCode!.Value);

        if (hikingTrail is null)
            throw new NotFoundEntityException(nameof(HikingTrail), createEntityDto.HikingTrailCode!.Value);
        
        prestige.HikingTrail = hikingTrail;
        prestige.HikingTrailId = hikingTrail.Id;

        if (await _prestigeRepository.GetByCodeAccountsAndHikingTrailAsync(prestige) is not null)
            throw new Exception("The user has already given prestige to that hiking trail");
        
        if (prestige.Code == Guid.Empty)
            prestige.Code = Guid.NewGuid();

        await _prestigeRepository.AddAsync(prestige);

        return prestige.Code;
    }

    public async Task DeleteByAccountAndHikingTrail(DeletePrestigeEntityDto deletePrestigeEntityDto)
    {
        if (!deletePrestigeEntityDto.HikingTrailCode.HasValue)
            throw new ArgumentNullException(nameof(deletePrestigeEntityDto.HikingTrailCode));
        if (!deletePrestigeEntityDto.ReceiverAccountCode.HasValue)
            throw new ArgumentNullException(nameof(deletePrestigeEntityDto.ReceiverAccountCode));
        if (!deletePrestigeEntityDto.GiverAccountCode.HasValue)
            throw new ArgumentNullException(nameof(deletePrestigeEntityDto.GiverAccountCode));
       
        HikingTrail? hikingTrail = await _hikingTrailRepository.GetByCodeAsync(deletePrestigeEntityDto.HikingTrailCode.Value);

        if (hikingTrail is null)
            throw new NotFoundEntityException(nameof(HikingTrail), deletePrestigeEntityDto.HikingTrailCode.Value);

        Prestige? prestige = await _prestigeRepository.GetByCodeAccountsAndHikingTrailAsync(new Prestige()
        {
            HikingTrail = hikingTrail,
            HikingTrailId = hikingTrail.Id,
            ReceiverAccountCode = deletePrestigeEntityDto.ReceiverAccountCode.Value,
            GiverAccountCode = deletePrestigeEntityDto.GiverAccountCode.Value
        });

        if (prestige is null)
            throw new NotFoundEntityException($"The user {deletePrestigeEntityDto.GiverAccountCode} " +
                                              $"has not given prestige to the hiking trail {deletePrestigeEntityDto.HikingTrailCode}.");

        await _prestigeRepository.DeleteAsync(prestige);
    }

    protected override void CheckDataValidity(CreatePrestigeEntityDto createEntityDto)
    {
        if (createEntityDto.HikingTrailCode.HasValue)
            Validator.CheckGuid(createEntityDto.HikingTrailCode.Value);
        
        if (createEntityDto.ReceiverAccountCode.HasValue)
            Validator.CheckGuid(createEntityDto.ReceiverAccountCode.Value);
        
        if (createEntityDto.GiverAccountCode.HasValue)
            Validator.CheckGuid(createEntityDto.GiverAccountCode.Value);
    }
    
}