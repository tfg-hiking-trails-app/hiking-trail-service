using AutoMapper;
using HikingTrailService.Application.DTOs.Common;
using HikingTrailService.Domain.Common;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class CommonEntityProfile : Profile
{
    public CommonEntityProfile()
    {
        CreateMap<FilterEntityDto, FilterData>().ReverseMap();
    }
}