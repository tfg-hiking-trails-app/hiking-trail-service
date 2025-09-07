using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class TrailTypeEntityProfile : Profile
{
    public TrailTypeEntityProfile()
    {
        CreateMap<TrailTypeEntityDto, TrailType>().ReverseMap();
        CreateMap<CreateTrailTypeEntityDto, TrailType>().ReverseMap();
        CreateMap<UpdateTrailTypeEntityDto, TrailType>()
            .ForAllMembers(opt => opt
                .Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<TrailType, UpdateTrailTypeEntityDto>();
    }
}