using AutoMapper;
using Common.Application.Services;
using Common.Domain.Exceptions;
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
    private readonly ICommentRepository _commentRepository;
    private readonly IHikingTrailRepository _hikingTrailRepository;
    
    public CommentService(
        ICommentRepository commentRepository,
        IHikingTrailRepository hikingTrailRepository,
        IMapper mapper) : base(commentRepository, mapper)
    {
        _commentRepository = commentRepository;
        _hikingTrailRepository = hikingTrailRepository;
    }
    
    public override async Task<Guid> CreateAsync(CreateCommentEntityDto createEntityDto)
    {
        CheckDataValidity(createEntityDto);
        
        HikingTrail? hikingTrail = await _hikingTrailRepository.GetByCodeAsync(createEntityDto.HikingTrailCode);
        
        if (hikingTrail is null)
            throw new NotFoundEntityException(nameof(HikingTrail), createEntityDto.HikingTrailCode);
        
        Comment comment = Mapper.Map<Comment>(createEntityDto);
        
        comment.HikingTrail = hikingTrail;
        comment.HikingTrailId = hikingTrail.Id;
        
        if (comment.Code == Guid.Empty)
            comment.Code = Guid.NewGuid();

        await _commentRepository.AddAsync(comment);

        return comment.Code;
    }

    protected override void CheckDataValidity(CreateCommentEntityDto createEntityDto)
    {
    }
}