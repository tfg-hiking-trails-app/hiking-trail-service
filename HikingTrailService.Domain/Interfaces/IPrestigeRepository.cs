using Common.Domain.Interfaces;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Domain.Interfaces;

public interface IPrestigeRepository : IRepository<Prestige>
{
    Task<Prestige?> GetByCodeAccountsAndHikingTrailAsync(Prestige prestige);
}