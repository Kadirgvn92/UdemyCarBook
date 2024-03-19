using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.PricingCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.PricingHandlers;
public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
{
    private readonly IRepository<Pricing> _repository;

    public RemovePricingCommandHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
    {
       var values = await _repository.GetByIDAsync(request.Id);
        await _repository.DeleteAsync(values);
    }
}
