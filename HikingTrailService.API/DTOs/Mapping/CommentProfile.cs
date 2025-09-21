using AutoMapper;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Update;

namespace HikingTrailService.DTOs.Mapping;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<CommentDto, CommentEntityDto>().ReverseMap();
        CreateMap<CreateCommentDto, CreateCommentEntityDto>().ReverseMap();
        CreateMap<UpdateCommentDto, UpdateCommentEntityDto>().ReverseMap();
    }
}