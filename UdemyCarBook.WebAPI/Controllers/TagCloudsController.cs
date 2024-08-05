using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;

namespace UdemyCarBook.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TagCloudsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TagCloudsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> TagCloudList()
    {
        var values = await _mediator.Send(new GetTagCloudQuery());
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
    {
        await _mediator.Send(command);
        return Ok("Etiket eklendi");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTagCloud(int id)
    {
        var values = await _mediator.Send(new GetTagCloudByIdQuery(id));
        return Ok(values);
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveTagCloud(int id)
    {
        await _mediator.Send(new RemoveTagCloudCommand(id));
        return Ok("Etiket silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
    {
        await _mediator.Send(command);
        return Ok("Etiket güncellendi");
    }
    [HttpGet("GetTagCloudByBlogId")]
    public async Task<IActionResult> GetTagCloudByBlogIdG(int id)
    {
        var values = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
        return Ok(values);
    }
}
