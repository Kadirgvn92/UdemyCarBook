using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.LocationCommands;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;
public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _Repository;

    public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
    {
        _Repository = repository;
    }

    public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        await _Repository.CreateAsync(new SocialMedia()
        {
            Name = request.Name,
            Icon = request.Icon,
            Url = request.Url,
        });
    }
}
