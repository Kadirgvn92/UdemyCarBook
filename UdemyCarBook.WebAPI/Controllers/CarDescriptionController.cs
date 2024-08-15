using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Queries.CarQueries;

namespace UdemyCarBook.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarDescriptionController : ControllerBase
{
	private readonly IMediator _mediator;

	public CarDescriptionController(IMediator mediator)
	{
		_mediator = mediator;
	}
	[HttpGet]
	public async Task<IActionResult> CarDescription(int id)
	{
		var values = await _mediator.Send(new GetCarDescriptionQuery(id));
		return Ok(values);
	}
}
