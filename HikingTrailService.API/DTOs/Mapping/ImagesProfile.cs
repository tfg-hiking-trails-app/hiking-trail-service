using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Update;

namespace HikingTrailService.DTOs.Mapping;

public class ImagesProfile : Profile
{
    public ImagesProfile()
    {
        CreateMap<ImagesDto, ImagesEntityDto>();
        CreateMap<CreateImagesDto, CreateImagesEntityDto>();
        CreateMap<UpdateImagesDto, UpdateImagesEntityDto>();
    }
}