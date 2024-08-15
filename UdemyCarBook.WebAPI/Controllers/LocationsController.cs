using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.LocationCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;

namespace UdemyCarBook.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> LocationList()
    {
        var values = await _mediator.Send(new GetLocationQuery());
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
    {
        await _mediator.Send(command);
        return Ok("Konum bilgisi eklendi");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLocation(int id)
    {
        var values = await _mediator.Send(new GetLocationByIdQuery(id));
        return Ok(values);
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveLocation(int id)
    {
        await _mediator.Send(new RemoveLocationCommand(id));
        return Ok("Konum bilgisi silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
    {
        await _mediator.Send(command);
        return Ok("Konum bilgisi güncellendi");
    }
}
