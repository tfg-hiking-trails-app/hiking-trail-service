using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Update;

namespace HikingTrailService.DTOs.Mapping;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        CreateMap<LocationDto, LocationEntityDto>().ReverseMap();
        CreateMap<CreateLocationDto, CreateLocationEntityDto>().ReverseMap();
        CreateMap<UpdateLocationDto, UpdateLocationEntityDto>().ReverseMap();
    }
}