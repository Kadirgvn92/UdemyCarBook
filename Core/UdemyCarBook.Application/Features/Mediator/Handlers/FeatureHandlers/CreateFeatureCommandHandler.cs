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
public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
{
    private readonly IRepository<Feature> _featureRepository;

    public CreateFeatureCommandHandler(IRepository<Feature> featureRepository)
    {
        _featureRepository = featureRepository;
    }

    public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        await _featureRepository.CreateAsync(new Feature
        {
            Name = request.Name
        });
    }
}
