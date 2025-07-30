using AutoMapper;
using HikingTrailService.Application.Common.Pagination;

namespace HikingTrailService.Infrastructure.Converters;

public class PageConverter<TSource, TDestination> : ITypeConverter<Page<TSource>, Page<TDestination>>
{
    public Page<TDestination> Convert(
        Page<TSource> source, 
        Page<TDestination> destination, 
        ResolutionContext context)
    {
        var mappedItems = context.Mapper.Map<List<TDestination>>(source.Content.ToList());
        return new Page<TDestination>(mappedItems, source.PageNumber, source.PageSize, source.TotalCount);
    }
}