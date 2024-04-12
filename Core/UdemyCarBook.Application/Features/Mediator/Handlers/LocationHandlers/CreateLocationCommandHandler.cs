using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.LocationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandlers;
public class CreateSocialMediaCommandHandler : IRequestHandler<CreateLocationCommand>
{
    private readonly IRepository<Location> _locationRepository;

    public CreateSocialMediaCommandHandler(IRepository<Location> locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        await _locationRepository.CreateAsync(new Location
        {
            Name = request.Name,
        });
    }
}
