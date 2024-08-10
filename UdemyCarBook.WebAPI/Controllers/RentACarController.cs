using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.PricingCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.PricingQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries;

namespace UdemyCarBook.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RentACarController : ControllerBase
{
    private readonly IMediator _mediator;

    public RentACarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> GetRentACarListByLocation(GetRentACarQuery query)
    {
        var values = await _mediator.Send(query);
        return Ok(values);
    }
    
}
