using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers;
public class UpdateCarFeatureAvailableToFalseQueryHandler : IRequestHandler<UpdateCarFeatureAvailableToFalseCommand>
{
    private readonly ICarFeatureRepository _carFeatureRepository;

    public UpdateCarFeatureAvailableToFalseQueryHandler(ICarFeatureRepository carFeatureRepository)
    {
        _carFeatureRepository = carFeatureRepository;
    }

    public async Task Handle(UpdateCarFeatureAvailableToFalseCommand request, CancellationToken cancellationToken)
    {
        _carFeatureRepository.ChangeCarFeatureAvailableToFalse(request.Id);

    }
}
