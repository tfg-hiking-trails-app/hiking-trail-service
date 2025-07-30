using AutoMapper;
using HikingTrailService.Application.Common.Pagination;
using HikingTrailService.Application.DTOs.Common;
using HikingTrailService.DTOs.Filter;
using HikingTrailService.Infrastructure.Converters;

namespace HikingTrailService.DTOs.Mapping;

public class CommonProfile : Profile
{
    public CommonProfile()
    {
        CreateMap<FilterDto, FilterEntityDto>().ReverseMap();
        CreateMap(typeof(Page<>), typeof(Page<>)).ConvertUsing(typeof(PageConverter<,>));
    }
}