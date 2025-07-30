using AutoMapper;
using HikingTrailService.Application.DTOs;

namespace HikingTrailService.DTOs.Mapping;

public class HikingTrailProfile : Profile
{
    public HikingTrailProfile()
    {
        CreateMap<HikingTrailDto, HikingTrailEntityDto>().ReverseMap();
    }
}