using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;

namespace UdemyCarBook.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly CreateCarCommandHandler _createCarCommandHandler;
    private readonly GetCarByIDQueryHandler _getCarByIdQueryHandler;
    private readonly GetCarQueryHandler _getCarQueryHandler;
    private readonly GetCarWithBrandQueryHandler _getCarWithQueryHandler;
    private readonly UpdateCarCommandHandler _updateCarCommandHandler;
    private readonly RemoveCarCommandHandler _removeCarCommandHandler;
    private readonly GetLast5CarsWithBrandQueryHandler _getLast5CarsWithBrandQueryHandler;
    private readonly GetCarWithBrandByIdQueryHandler _getCarWithBrandByIdQueryHandler;
    private readonly IMediator _mediator;

	public CarController(CreateCarCommandHandler createCarCommandHandler,
		GetCarByIDQueryHandler getCarByIdQueryHandler,
		GetCarQueryHandler getCarQueryHandler,
		UpdateCarCommandHandler updateCarCommandHandler,
		RemoveCarCommandHandler removeCarCommandHandler,
		GetCarWithBrandQueryHandler getCarWithQueryHandler,
		GetLast5CarsWithBrandQueryHandler getLast5CarsWithBrandQueryHandler
,
		IMediator mediator,
		GetCarWithBrandByIdQueryHandler getCarWithBrandByIdQueryHandler)
	{
		_createCarCommandHandler = createCarCommandHandler;
		_getCarByIdQueryHandler = getCarByIdQueryHandler;
		_getCarQueryHandler = getCarQueryHandler;
		_updateCarCommandHandler = updateCarCommandHandler;
		_removeCarCommandHandler = removeCarCommandHandler;
		_getCarWithQueryHandler = getCarWithQueryHandler;
		_getLast5CarsWithBrandQueryHandler = getLast5CarsWithBrandQueryHandler;
		_mediator = mediator;
		_getCarWithBrandByIdQueryHandler = getCarWithBrandByIdQueryHandler;
	}

	[HttpGet]
    public async Task<IActionResult> CarList()
    {
        var values = await _getCarQueryHandler.Handle();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCar(int id)
    {
        var values = await _getCarByIdQueryHandler.Handle(new GetCarByIDQuery(id));
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarCommand command)
    {
        await _createCarCommandHandler.Handle(command);
        return Ok("Araç bilgii eklendi");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveCar(int id)
    {
        await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
        return Ok("Araç bilgisi silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
    {
        await _updateCarCommandHandler.Handle(command);
        return Ok("Araç bilgisi güncellendi");
    }
    [HttpGet("GetCarWithBrand")]
    public IActionResult GetCarWithBrand()
    {
        var values =  _getCarWithQueryHandler.Handle();
        return Ok(values);
    }
    [HttpGet("GetLast5CarWithBrand")]
    public IActionResult GetLast5CarWithBrand()
    {
        var values = _getLast5CarsWithBrandQueryHandler.Handle();
        return Ok(values);
    }
	[HttpGet("GetCarWithBrandById/{id}")]
	public async Task<IActionResult> GetCarWithBrandById(int id)
	{
		var values = await _getCarWithBrandByIdQueryHandler.Handle(new GetCarWithBrandByIdQuery(id));
		return Ok(values);
	}


}
