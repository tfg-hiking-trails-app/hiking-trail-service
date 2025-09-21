using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Domain.Entities;

namespace HikingTrailService.Infrastructure.Data.Configurations.Mapping;

public class CommentEntityProfile : Profile
{
    public CommentEntityProfile()
    {
        CreateMap<CommentEntityDto, Comment>().ReverseMap();
        CreateMap<CreateCommentEntityDto, Comment>().ReverseMap();
        CreateMap<UpdateCommentEntityDto, Comment>().ReverseMap();
    }
}