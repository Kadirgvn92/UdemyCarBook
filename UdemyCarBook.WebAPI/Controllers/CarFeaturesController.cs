﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        var values = _mediator.Send(new GetCarFeatureByCarIdQuery(id));
        return Ok(values);
    }
}
