using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.ServiceQueries;
using UdemyCarBook.Application.Features.Mediator.Results.PricingResults;
using UdemyCarBook.Application.Features.Mediator.Results.ServiceResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers;
public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
{
    private readonly IRepository<Service> _serviceRepository;

    public GetServiceByIdQueryHandler(IRepository<Service> serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _serviceRepository.GetByIDAsync(request.Id);
        return new GetServiceByIdQueryResult
        {
            Description = values.Description,
            Icon = values.Icon,
            ServiceID = values.ServiceID,
            Title = values.Title    
        };
    }
}
