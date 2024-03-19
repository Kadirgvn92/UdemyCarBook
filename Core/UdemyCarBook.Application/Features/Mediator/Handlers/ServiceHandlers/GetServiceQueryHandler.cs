using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.ServiceQueries;
using UdemyCarBook.Application.Features.Mediator.Results.ServiceResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers;
public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
{
    private readonly IRepository<Service> _serviceRepository;

    public GetServiceQueryHandler(IRepository<Service> serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
        var values = await _serviceRepository.GetAllAsync();
        return values.Select(x => new GetServiceQueryResult
        {
            Description = x.Description,
            Icon = x.Icon,
            ServiceID = x.ServiceID,
            Title = x.Title,    
        }).ToList();
    }
}
