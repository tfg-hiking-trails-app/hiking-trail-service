using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class HikingTrailEntityProfile : Profile
{
    public HikingTrailEntityProfile()
    {
        CreateMap<HikingTrailEntityDto, HikingTrail>().ReverseMap();
    }
}