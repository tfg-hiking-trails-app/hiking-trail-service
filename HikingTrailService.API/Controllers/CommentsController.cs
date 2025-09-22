using AutoMapper;
using Common.API.Controllers;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;
using HikingTrailService.Application.Interfaces;
using HikingTrailService.DTOs;
using HikingTrailService.DTOs.Create;
using HikingTrailService.DTOs.Update;
using Microsoft.AspNetCore.Mvc;

namespace HikingTrailService.Controllers;

[Route("api/comment")]
public class CommentsController : AbstractCrudController<CommentDto, CreateCommentDto, UpdateCommentDto, 
    CommentEntityDto, CreateCommentEntityDto, UpdateCommentEntityDto>
{
    public CommentsController(
        ICommentService service, 
        IMapper mapper) : base(service, mapper)
    {
    }
}