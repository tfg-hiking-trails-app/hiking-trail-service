using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class CollectionEntityProfile : Profile
{
    public CollectionEntityProfile()
    {
        CreateMap<Collection, CollectionEntityDto>()
            .ForMember(dest => dest.TrailCount, opt => opt.MapFrom(src => src.CollectionTrails.Count));

        CreateMap<CollectionEntityDto, Collection>();

        CreateMap<CreateCollectionEntityDto, Collection>().ReverseMap();

        CreateMap<UpdateCollectionEntityDto, Collection>()
            .ForAllMembers(opt => opt
                .Condition((src, dest, srcMember) => srcMember != null));
    }
}
