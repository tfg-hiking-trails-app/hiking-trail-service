using AutoMapper;
using Common.Application.Services;
using Common.Application.Utils;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Application.Services;

public class ImagesService : AbstractService<Images, ImagesEntityDto, CreateImagesEntityDto, 
    UpdateImagesEntityDto>, IImagesService
{
    public ImagesService(IImagesRepository hikingTrailRepository, IMapper mapper) : base(hikingTrailRepository, mapper)
    {
    }

    protected override void CheckDataValidity(CreateImagesEntityDto createEntityDto)
    {
        Validator.CheckNullArgument(createEntityDto.ImageUrl, nameof(createEntityDto.ImageUrl));
    }
    
}