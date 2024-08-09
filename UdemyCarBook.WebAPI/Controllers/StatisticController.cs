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
    [HttpGet("GetLocationCount")]
    public async Task<IActionResult> GetLocationCount()
    {
        var values = await _mediator.Send(new GetLocationCountQuery());
        return Ok(values);
    }

    [HttpGet("GetAuhtorCount")]
    public async Task<IActionResult> GetAuhtorCount()
    {
        var values = await _mediator.Send(new GetAuthorCountQuery());
        return Ok(values);
    }

    [HttpGet("GetBlogCount")]
    public async Task<IActionResult> GetBlogCount()
    {
        var values = await _mediator.Send(new GetBlogCountQuery());
        return Ok(values);
    }

    [HttpGet("GetPricingCount")]
    public async Task<IActionResult> GetPricingCount()
    {
        var values = await _mediator.Send(new GetPricingCountQuery());
        return Ok(values);
    }

    [HttpGet("GetCarFeatureCount")]
    public async Task<IActionResult> GetCarFeatureCount()
    {
        var values = await _mediator.Send(new GetCarFeatureCountQuery());
        return Ok(values);
    }

    [HttpGet("GetMostExpensivePrice")]
    public async Task<IActionResult> GetMostExpensivePrice()
    {
        var values = await _mediator.Send(new GetMostExpensivePriceQuery());
        return Ok(values);
    }

    [HttpGet("GetWeeklyAvgRentPrice")]
    public async Task<IActionResult> GetWeeklyAvgRentPrice()
    {
        var values = await _mediator.Send(new GetWeeklyAvgRentPriceQuery());
        return Ok(values);
    }

    [HttpGet("GetMostCheapPrice")]
    public async Task<IActionResult> GetMostCheapPrice()
    {
        var values = await _mediator.Send(new GetMostCheapPriceQuery());
        return Ok(values);
    }

    [HttpGet("GetMostExpensiveCar")]
    public async Task<IActionResult> GetMostExpensiveCar()
    {
        var values = await _mediator.Send(new GetMostExpensiveCarQuery());
        return Ok(values);
    }

    [HttpGet("GetMostCheapCar")]
    public async Task<IActionResult> GetMostCheapCar()
    {
        var values = await _mediator.Send(new GetMostCheapCarQuery());
        return Ok(values);
    }

    [HttpGet("GetTestimonialCount")]
    public async Task<IActionResult> GetTestimonialCount()
    {
        var values = await _mediator.Send(new GetTestimonialCountQuery());
        return Ok(values);
    }

    [HttpGet("GetDailyAvgRentPrice")]
    public async Task<IActionResult> GetDailyAvgRentPrice()
    {
        var values = await _mediator.Send(new GetDailyAvgRentPriceQuery());
        return Ok(values);
    }

    [HttpGet("GetHourlyAvgRentPrice")]
    public async Task<IActionResult> GetHourlyAvgRentPrice()
    {
        var values = await _mediator.Send(new GetHourlyAvgRentPriceQuery());
        return Ok(values);
    }

    [HttpGet("GetMontlyAvgRentPrice")]
    public async Task<IActionResult> GetMontlyAvgRentPrice()
    {
        var values = await _mediator.Send(new GetMontlyAvgRentPriceQuery());
        return Ok(values);
    }
    [HttpGet("GetServiceCount")]
    public async Task<IActionResult> GetServiceCount()
    {
        var values = await _mediator.Send(new GetServiceCountQuery());
        return Ok(values);
    }
}
