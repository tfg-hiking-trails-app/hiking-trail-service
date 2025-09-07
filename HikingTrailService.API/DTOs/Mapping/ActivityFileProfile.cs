using AutoMapper;
using HikingTrailService.Application.DTOs;

namespace HikingTrailService.DTOs.Mapping;

public class ActivityFileProfile : Profile
{
    public ActivityFileProfile()
    {
        CreateMap<ActivityFileUploadDto, ActivityFileEntityDto>()
            .ConstructUsing(src => MapActivityFile(src));
    }

    private ActivityFileEntityDto MapActivityFile(ActivityFileUploadDto dto)
    {
        if (dto.ActivityFile is null)
            throw new ArgumentNullException(nameof(dto.ActivityFile), "ActivityFile is null");
        
        using Stream stream = dto.ActivityFile.OpenReadStream();
        using MemoryStream memoryStream = new MemoryStream();
                
        stream.CopyTo(memoryStream);
                
        return new ActivityFileEntityDto
        {
            UserCode = Guid.Empty,
            ContentType = dto.ActivityFile!.ContentType,
            ContentDisposition = dto.ActivityFile!.ContentDisposition,
            Length = dto.ActivityFile!.Length,
            Name = dto.ActivityFile!.Name,
            FileName = dto.ActivityFile!.FileName,
            Content = memoryStream.ToArray()
        };
    }
}