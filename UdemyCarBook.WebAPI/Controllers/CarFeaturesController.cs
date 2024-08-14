using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQueries;

namespace UdemyCarBook.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarFeaturesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarFeaturesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> CarFeatureListByCarId(int id)
    {
        var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
        return Ok(values);
    }
    [HttpGet("CarFeatureChangeAvailableToFalse")]
    public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
    {
        _mediator.Send(new UpdateCarFeatureAvailableToFalseCommand(id));    
        return Ok("Güncelleme yapıldı");
    }
    [HttpGet("CarFeatureChangeAvailableToTrue")]
    public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
    {
        _mediator.Send(new UpdateCarFeatureAvailableToTrueCommand(id));
        return Ok("Güncelleme yapıldı");
    }
    [HttpPost("CreateCarFeatureByCar")]
    public async Task<IActionResult> CreateCarFeatureByCar(CreateCarFeatureByCarCommand command)
    {
        _mediator.Send(command);
        return Ok("Ekleme yapıldı");
    }
}
