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
public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
{
    private readonly IRepository<Service> _serviceRepository;

    public UpdateServiceCommandHandler(IRepository<Service> serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var values = await _serviceRepository.GetByIDAsync(request.ServiceID);
        values.Description = request.Description;
        values.Title = request.Title;
        values.Icon = request.Icon;
        await _serviceRepository.UpdateAsync(values);
    }
}
