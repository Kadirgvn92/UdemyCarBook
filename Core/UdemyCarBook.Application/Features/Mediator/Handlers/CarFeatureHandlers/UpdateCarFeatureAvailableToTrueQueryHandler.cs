using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers;
public class UpdateCarFeatureAvailableToTrueQueryHandler : IRequestHandler<UpdateCarFeatureAvailableToTrueCommand>
{
    private readonly ICarFeatureRepository _carFeatureRepository;

    public UpdateCarFeatureAvailableToTrueQueryHandler(ICarFeatureRepository carFeatureRepository)
    {
        _carFeatureRepository = carFeatureRepository;
    }

    public async Task Handle(UpdateCarFeatureAvailableToTrueCommand request, CancellationToken cancellationToken)
    {
        _carFeatureRepository.ChangeCarFeatureAvailableToTrue(request.Id);
    }
}
