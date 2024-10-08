﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries;

namespace UdemyCarBook.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarPricingsController : ControllerBase
{
	private readonly IMediator _mediator;

	public CarPricingsController(IMediator mediator)
	{
		_mediator = mediator;
	}
	[HttpGet("GetCarPricingWithCar")]
	public async Task<IActionResult> GetCarPricingWithCar()
	{
		var values = await _mediator.Send(new GetCarPricingWithCarQuery());
		return Ok(values);
	}
	[HttpGet("GetCarPricingWithTimePeriod")]
	public async Task<IActionResult> GetCarPricingWithTimePeriod()
	{
		var values = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());
		return Ok(values);
	}
}
