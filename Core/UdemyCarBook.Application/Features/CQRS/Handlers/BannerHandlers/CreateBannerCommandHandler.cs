using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
public class CreateBannerCommandHandler
{
    private readonly IRepository<Banner> _bannerRepository;

    public CreateBannerCommandHandler(IRepository<Banner> bannerRepository)
    {
        _bannerRepository = bannerRepository;
    }
    public async Task Handle(CreateBannerCommand command)
    {
        await _bannerRepository.CreateAsync(new Banner
        {
            Description = command.Description,
            Title = command.Title,
            Video = command.Video,
            VideoDescription = command.VideoDescription
        });
    }
}
