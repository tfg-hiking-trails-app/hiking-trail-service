using AutoMapper;
using Common.Application.Services;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.Domain.Entities;
using HikingTrailService.Domain.Interfaces;

namespace HikingTrailService.Application.Services;

public class CommentService : AbstractService<Comment, CommentEntityDto, CreateCommentEntityDto, 
    UpdateCommentEntityDto>, ICommentService
{
    public CommentService(ICommentRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    protected override void CheckDataValidity(CreateCommentEntityDto createEntityDto)
    {
    }
}