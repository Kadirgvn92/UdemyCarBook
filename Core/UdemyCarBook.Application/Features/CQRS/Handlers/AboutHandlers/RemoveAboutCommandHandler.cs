using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
public class RemoveAboutCommandHandler
{
    private readonly IRepository<About> _aboutRepository;

    public RemoveAboutCommandHandler(IRepository<About> aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }
    public async Task Handle(RemoveAboutCommand command)
    {
        var values = await _aboutRepository.GetByIDAsync(command.Id);
        await _aboutRepository.DeleteAsync(values);
    }
}
