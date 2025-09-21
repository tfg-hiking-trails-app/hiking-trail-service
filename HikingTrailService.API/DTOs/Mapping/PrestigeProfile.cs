using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Update;

namespace HikingTrailService.DTOs.Mapping;

public class PrestigeProfile : Profile
{
    public PrestigeProfile()
    {
        CreateMap<PrestigeDto, PrestigeEntityDto>().ReverseMap();
        CreateMap<CreatePrestigeDto, CreatePrestigeEntityDto>().ReverseMap();
        CreateMap<UpdatePrestigeDto, UpdatePrestigeEntityDto>().ReverseMap();
    }
}