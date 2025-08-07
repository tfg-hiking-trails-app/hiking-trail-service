using AutoMapper;
using Common.API.Controllers;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.DTOs;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Update;
using Microsoft.AspNetCore.Mvc;

namespace HikingTrailService.Controllers;

[Route("api/images")]
public class ImagesController : AbstractController<
    ImagesDto, CreateImagesDto, UpdateImagesDto, 
    ImagesEntityDto, CreateImagesEntityDto, UpdateImagesEntityDto>
{
    public ImagesController(
        IImagesService service, 
        IMapper mapper) : base(service, mapper)
    {
    }
}