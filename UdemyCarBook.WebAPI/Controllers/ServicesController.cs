﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.ServiceQueries;

namespace UdemyCarBook.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ServiceList()
    {
        var values = await _mediator.Send(new GetServiceQuery());
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateService(CreateServiceCommand command)
    {
        await _mediator.Send(command);
        return Ok("Hizmet bilgisi eklendi");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetService(int id)
    {
        var values = await _mediator.Send(new GetServiceByIdQuery(id));
        return Ok(values);
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveService(int id)
    {
        await _mediator.Send(new RemoveServiceCommand(id));
        return Ok("Hizmet bilgisi silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
    {
        await _mediator.Send(command);
        return Ok("Hizmet bilgisi güncellendi");
    }
}
