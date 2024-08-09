using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;

namespace UdemyCarBook.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StatisticController : Controller
{
    private readonly IMediator _mediator;

    public StatisticController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetCarCount")]
    public async Task<IActionResult> GetCarCount()
    {
        var values = await _mediator.Send(new GetCarCountQuery());
        return Ok(values);
    }
}
