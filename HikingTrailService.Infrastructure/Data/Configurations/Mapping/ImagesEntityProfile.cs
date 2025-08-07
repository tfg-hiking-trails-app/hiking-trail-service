using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class ImagesEntityProfile : Profile
{
    public ImagesEntityProfile()
    {
        CreateMap<ImagesEntityDto, Images>().ReverseMap();
        CreateMap<CreateImagesEntityDto, Images>().ReverseMap();
        CreateMap<UpdateImagesEntityDto, Images>().ReverseMap();
    }
}