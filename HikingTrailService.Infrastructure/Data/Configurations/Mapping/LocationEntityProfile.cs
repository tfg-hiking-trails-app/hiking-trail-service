using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class LocationEntityProfile : Profile
{
    public LocationEntityProfile()
    {
        CreateMap<LocationEntityDto, Location>().ReverseMap();
        CreateMap<CreateLocationEntityDto, Location>().ReverseMap();
        CreateMap<UpdateLocationEntityDto, Location>().ReverseMap();
    }
}