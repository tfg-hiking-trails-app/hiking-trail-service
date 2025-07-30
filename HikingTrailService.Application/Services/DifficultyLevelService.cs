using AutoMapper;
using HikingTrailService.Application.Common.Pagination;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Common;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces.Repositories;

namespace HikingTrailService.Application.Services;

public class DifficultyLevelService : IDifficultyLevelService
{
    private readonly IDifficultyLevelRepository _repository;
    private readonly IMapper _mapper;
    
    public DifficultyLevelService(
        IDifficultyLevelRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DifficultyLevelEntityDto>> GetAllAsync()
    {
        IEnumerable<DifficultyLevel> difficultyLevels = await _repository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<DifficultyLevelEntityDto>>(difficultyLevels);
    }

    public Task<Page<DifficultyLevelEntityDto>> GetPagedAsync(FilterEntityDto filter, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<DifficultyLevelEntityDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<DifficultyLevelEntityDto> GetByCodeAsync(Guid code)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> CreateAsync(CreateDifficultyLevelEntityDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> UpdateAsync(UpdateDifficultyLevelEntityDto entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid code)
    {
        throw new NotImplementedException();
    }
}