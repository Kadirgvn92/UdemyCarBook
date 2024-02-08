using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BannerQueries;

namespace UdemyCarBook.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BannerController : ControllerBase
{
    private readonly GetBannerByIdQueryHandler  _bannerByIdQueryHandle;
    private readonly GetBannerQueryHandler _bannerQueryHandler;
    private readonly CreateBannerCommandHandler _createBannerCommandHandler;
    private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
    private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

    public BannerController(GetBannerByIdQueryHandler bannerByIdQueryHandle, GetBannerQueryHandler bannerQueryHandler, CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler)
    {
        _bannerByIdQueryHandle = bannerByIdQueryHandle;
        _bannerQueryHandler = bannerQueryHandler;
        _createBannerCommandHandler = createBannerCommandHandler;
        _updateBannerCommandHandler = updateBannerCommandHandler;
        _removeBannerCommandHandler = removeBannerCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> BannerList()
    {
        var values = await _bannerQueryHandler.Handle();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBanner(int id)
    {
        var values = await _bannerByIdQueryHandle.Handle(new GetBannerByIdQuery(id));
        return Ok(values);  
    }
    [HttpPost]
    public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
    {
        await _createBannerCommandHandler.Handle(command);
        return Ok("Bilgi Eklendi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
    {
        await _updateBannerCommandHandler.Handle(command);
        return Ok("Bigli güncellendi");

    }
    [HttpDelete]  
    public async Task<IActionResult> RemoveBanner(RemoveBannerCommand command)
    {
        await _removeBannerCommandHandler.Handle(command);
        return Ok("Bilgi silindi");
    }
}
