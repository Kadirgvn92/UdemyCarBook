using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarFeatureResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers;
public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
{
    private readonly ICarFeatureRepository _carFeatureRepository;

    public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
    {
        _carFeatureRepository = carFeatureRepository;
    }

    public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
    {
        var valeus = _carFeatureRepository.GetCarFeaturesByCarID(request.Id);
        return valeus.Select(x => new GetCarFeatureByCarIdQueryResult
        {
            Available = x.Available,
            CarFeatureID = x.CarFeatureID,  
            FeatureID = x.FeatureID,
            FeatureName = x.Feature.Name,
        }).ToList();
    }
}
