using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;
public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _SocialMediaRepository;

    public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> SocialMediaRepository)
    {
        _SocialMediaRepository = SocialMediaRepository;
    }

    public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var values = await _SocialMediaRepository.GetByIDAsync(request.Id);
        await _SocialMediaRepository.DeleteAsync(values);
    }
}
