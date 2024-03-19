using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers;
public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
{
    private readonly IRepository<Service> _serviceRepository;

    public CreateServiceCommandHandler(IRepository<Service> serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        await _serviceRepository.CreateAsync(new Service
        {
            Description = request.Description,
            Icon = request.Icon,
            Title = request.Title,
        });
    }
}
