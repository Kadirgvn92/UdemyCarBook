using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAddressResult;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandlers;
public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
{
    private readonly IRepository<Location> _locationRepository;

    public GetLocationByIdQueryHandler(IRepository<Location> locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _locationRepository.GetByIDAsync(request.Id);
        return new GetLocationByIdQueryResult
        {
            LocationID = values.LocationID,
            Name = values.Name,
        };
    }
}
