using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class PrestigeEntityProfile : Profile
{
    public PrestigeEntityProfile()
    {
        CreateMap<PrestigeEntityDto, Prestige>().ReverseMap();
        CreateMap<CreatePrestigeEntityDto, Prestige>().ReverseMap();
        CreateMap<UpdatePrestigeEntityDto, Prestige>().ReverseMap();
    }
}