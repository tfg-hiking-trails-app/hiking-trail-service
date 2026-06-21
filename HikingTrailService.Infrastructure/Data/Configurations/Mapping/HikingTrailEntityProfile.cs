using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Recommender;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class HikingTrailEntityProfile : Profile
{
    public HikingTrailEntityProfile()
    {
        CreateMap<HikingTrailEntityDto, HikingTrail>().ReverseMap();
        CreateMap<RecommenderEntityDto, RecommenderData>().ReverseMap();
        CreateMap<CreateHikingTrailEntityDto, HikingTrail>()
            .ForMember(dst => dst.Metrics, opt => opt.Ignore())
            .ForMember(dst => dst.Images, opt => opt.Ignore());
        CreateMap<HikingTrail, CreateHikingTrailEntityDto>()
            .ForMember(dst => dst.Metrics, opt => opt.Ignore())
            .ForMember(dst => dst.Images, opt => opt.Ignore());
        CreateMap<UpdateHikingTrailEntityDto, HikingTrail>()
            .ForMember(dst => dst.Images, opt => opt.Ignore())
            .ForAllMembers(opt => opt
                .Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<HikingTrail, UpdateHikingTrailEntityDto>()
            .ForMember(dst => dst.Images, opt => opt.Ignore());
    }
}