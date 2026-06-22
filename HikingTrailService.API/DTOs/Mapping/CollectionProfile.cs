using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Update;

namespace HikingTrailService.DTOs.Mapping;

public class CollectionProfile : Profile
{
    public CollectionProfile()
    {
        CreateMap<CollectionDto, CollectionEntityDto>().ReverseMap();
        CreateMap<CreateCollectionDto, CreateCollectionEntityDto>().ReverseMap();
        CreateMap<UpdateCollectionDto, UpdateCollectionEntityDto>().ReverseMap();
    }
}
