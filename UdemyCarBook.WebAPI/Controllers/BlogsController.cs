using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;

namespace UdemyCarBook.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BlogsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> BlogList()
    {
        var values = await _mediator.Send(new GetBlogQuery());
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlog(int id)
    {
        var values = await _mediator.Send(new GetBlogByIdQuery(id));
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
    {
        await _mediator.Send(command);
        return Ok("Blog added successfully");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveBlog(int id)
    {
        await _mediator.Send(new RemoveBlogCommand(id));
        return Ok("Blog deleted successfully");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
    {
        await _mediator.Send(command);
        return Ok("Blog updated successfully");
    }
    [HttpGet("GetLast3BlogsWithAuthorsList")]
    public async Task<IActionResult> GetLast3BlogsWithAuthorsList()
    {
        var values = await _mediator.Send(new GetLast3BlogsWithAuthorsQuery());
        return Ok(values);  
    }

    [HttpGet("GetAllBlogsWithAuthorList")]
    public async Task<IActionResult> GetAllBlogsWithAuthorList()
    {
        var values = await _mediator.Send(new GetAllBlogsWithAuthorQuery());
        return Ok(values);
    }
    [HttpGet("GetBlogByAuthorId")]
    public async Task<IActionResult> GetBlogByAuthorId(int id)
    {
        var values = await _mediator.Send(new GetBlogByAuthorIdQuery(id));
        return Ok(values);
    }
}
