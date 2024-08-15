using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.ReviewQueries;
using UdemyCarBook.Application.Validator;

namespace UdemyCarBook.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetReviewByCarID(int id)
    {
        var values = await _mediator.Send(new GetReviewByCarIDQuery(id));
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateReview(CreateReviewCommand command)
    {
        CreateReviewValidator validator = new CreateReviewValidator();
        var validationResult = validator.Validate(command);

        if(!validationResult.IsValid)
        {
			await _mediator.Send(command);
			return Ok("Ekleme işlemi gerçekleşti");
		}
        return BadRequest("Eklemede sıkıntı oluştu");
       
    }
}
