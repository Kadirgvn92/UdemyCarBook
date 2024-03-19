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
public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
{
    private readonly IRepository<Location> _locationRepository;

    public GetLocationQueryHandler(IRepository<Location> locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var values = await _locationRepository.GetAllAsync();
        return values.Select(x => new GetLocationQueryResult
        {
           Name = x.Name,
           LocationID = x.LocationID,
        }).ToList();
    }
}
