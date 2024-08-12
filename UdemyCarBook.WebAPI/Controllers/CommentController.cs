﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly IGenericRepository<Comment> _repository;
    private readonly IMediator _mediator;

    public CommentController(IGenericRepository<Comment> repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }
    [HttpGet]
    public IActionResult CommentList()
    {
        var values = _repository.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetComment(int id)
    {
        var values = _repository.GetById(id);
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateComment(Comment comment)
    {
        
        _repository.Add(comment);
        return Ok("Comment added successfully");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveComment(int id)
    {
        _repository.Remove(_repository.GetById(id));
        return Ok("Comment deleted successfully");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateComment(Comment comment)
    {
        _repository.Update(comment);
        return Ok("Comment updated successfully");
    }
    [HttpGet("CommentListByBlog")]
    public IActionResult CommentListByBlog(int id)
    {
        var values = _repository.GetCommentsByBlogId(id);
        return Ok(values);
    }
    [HttpGet("CommentCountByBlog")]
    public IActionResult CommentCountByBlog(int id)
    {
        var values = _repository.GetCountCommentByBlog(id);
        return Ok(values);
    }
    [HttpPost("CreateCommentWithMediatR")]
    public async Task<IActionResult> CreateCommentWithMediatR(CreateCommentCommand command)
    {
        await _mediator.Send(command);
        return Ok("Yorum başarıyla eklendi");
    }
}
