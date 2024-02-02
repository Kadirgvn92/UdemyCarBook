using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
public class UpdateAboutCommandHandler
{
    private readonly IRepository<About> _aboutRepository;

    public UpdateAboutCommandHandler(IRepository<About> aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }
    public async Task Handle(UpdateAboutCommand command)
    {
        var values = await _aboutRepository.GetByIDAsync(command.AboutID);
        values.Title = command.Title;
        values.Description = command.Description;
        values.ImageUrl = command.ImageUrl;
        await _aboutRepository.UpdateAsync(values);
    }
}
