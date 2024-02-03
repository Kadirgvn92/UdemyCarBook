using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
public class UpdateBannerCommandHandler
{
    private readonly IRepository<Banner> _bannerRepository;

    public UpdateBannerCommandHandler(IRepository<Banner> bannerRepository)
    {
        _bannerRepository = bannerRepository;
    }
    public async Task Handle(UpdateBannerCommand command)
    {
        var values = await _bannerRepository.GetByIDAsync(command.BannerID);
        values.VideoDescription = command.VideoDescription;
        values.Title = command.Title;
        values.Video = command.Video;   
        values.Description = command.Description;
        await _bannerRepository.UpdateAsync(values);
    }
}
