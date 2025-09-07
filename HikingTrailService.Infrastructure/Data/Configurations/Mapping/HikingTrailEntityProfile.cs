using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class HikingTrailEntityProfile : Profile
{
    public HikingTrailEntityProfile()
    {
        CreateMap<HikingTrailEntityDto, HikingTrail>().ReverseMap();
        CreateMap<CreateHikingTrailEntityDto, HikingTrail>().ReverseMap();
        CreateMap<UpdateHikingTrailEntityDto, HikingTrail>()
            .ForAllMembers(opt => opt
                .Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<HikingTrail, UpdateHikingTrailEntityDto>();
    }
}