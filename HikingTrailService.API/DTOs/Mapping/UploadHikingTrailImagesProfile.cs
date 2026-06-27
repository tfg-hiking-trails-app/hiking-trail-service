using AutoMapper;
using Common.Application;
using HikingTrailService.Application.DTOs;
using HikingTrailService.DTOs;

namespace HikingTrailService.DTOs.Mapping;

public class UploadHikingTrailImagesProfile : Profile
{
    public UploadHikingTrailImagesProfile()
    {
        CreateMap<UploadHikingTrailImagesDto, UploadHikingTrailImagesEntityDto>()
            .ConstructUsing(src => MapUploadImages(src));
    }

    private static UploadHikingTrailImagesEntityDto MapUploadImages(UploadHikingTrailImagesDto dto)
    {
        if (dto.Images is null)
            throw new ArgumentNullException(nameof(dto.Images), "Images is null");

        List<FileEntityDto> images = new List<FileEntityDto>();

        foreach (IFormFile? image in dto.Images)
        {
            if (image is null)
                throw new ArgumentNullException(nameof(dto.Images), "One of the images is null");

            using Stream stream = image.OpenReadStream();
            using MemoryStream memoryStream = new MemoryStream();

            stream.CopyTo(memoryStream);

            images.Add(new FileEntityDto
            {
                ContentType = image.ContentType,
                ContentDisposition = image.ContentDisposition,
                Length = image.Length,
                Name = image.Name,
                FileName = image.FileName,
                Content = memoryStream.ToArray()
            });
        }

        return new UploadHikingTrailImagesEntityDto
        {
            Images = images
        };
    }
}
