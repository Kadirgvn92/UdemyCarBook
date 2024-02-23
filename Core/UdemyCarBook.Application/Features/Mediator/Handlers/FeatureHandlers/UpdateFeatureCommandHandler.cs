using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
{
    private readonly IRepository<Feature> _featureRepository;

    public UpdateFeatureCommandHandler(IRepository<Feature> featureRepository)
    {
        _featureRepository = featureRepository;
    }

    public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        var values = await _featureRepository.GetByIDAsync(request.FeatureID);
        values.Name = request.Name;
        await _featureRepository.UpdateAsync(values);
    }
}
