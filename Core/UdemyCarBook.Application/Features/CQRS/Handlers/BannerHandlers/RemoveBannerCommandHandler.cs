using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
public class RemoveBannerCommandHandler
{
    private readonly IRepository<Banner> _bannerRepository;

    public RemoveBannerCommandHandler(IRepository<Banner> bannerRepository)
    {
        _bannerRepository = bannerRepository;
    }
    public async Task Handle(RemoveBannerCommand command)
    {
        var values = await _bannerRepository.GetByIDAsync(command.Id);
        await _bannerRepository.DeleteAsync(values);
    }
}
