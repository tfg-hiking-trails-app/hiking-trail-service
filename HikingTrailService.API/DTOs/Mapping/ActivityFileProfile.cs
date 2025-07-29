using AutoMapper;
using HikingTrailService.Application.DTOs;

namespace HikingTrailService.DTOs.Mapping;

public class ActivityFileProfile : Profile
{
    public ActivityFileProfile()
    {
        CreateMap<ActivityFileUploadDto, ActivityFileEntityDto>()
            .BeforeMap((src, dest) =>
            {
                if (src.ActivityFile is null)
                    throw new ArgumentNullException(nameof(src.ActivityFile), "ActivityFile is null");
            })
            .ForMember(dest => dest.ContentType, 
                opt => opt.MapFrom(src => src.ActivityFile!.ContentType))
            .ForMember(dest => dest.ContentDisposition, 
                opt => opt.MapFrom(src => src.ActivityFile!.ContentDisposition))
            .ForMember(dest => dest.Length, 
                opt => opt.MapFrom(src => src.ActivityFile!.Length))
            .ForMember(dest => dest.Name, 
                opt => opt.MapFrom(src => src.ActivityFile!.Name))
            .ForMember(dest => dest.FileName, 
                opt => opt.MapFrom(src => src.ActivityFile!.FileName))
            .AfterMap((src, dest) =>
            {
                Stream result = new MemoryStream();
                src.ActivityFile!.CopyTo(result);
                dest.Content = result;
            });
    }
}