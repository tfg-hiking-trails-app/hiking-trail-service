using Common.Application.Interfaces;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Delete;
using HikingTrailService.Application.DTOs.Update;

namespace HikingTrailService.Application.Interfaces;

public interface IPrestigeService : IService<PrestigeEntityDto, CreatePrestigeEntityDto, UpdatePrestigeEntityDto>
{
    Task<Guid> DeleteByAccountAndHikingTrail(DeletePrestigeEntityDto deletePrestigeEntityDto);
    
}