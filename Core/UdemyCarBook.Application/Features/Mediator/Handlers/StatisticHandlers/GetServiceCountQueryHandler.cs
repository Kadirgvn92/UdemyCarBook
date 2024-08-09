using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
using UdemyCarBook.Application.Interfaces.StatisticInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticHandlers;
public class GetServiceCountQueryHandler : IRequestHandler<GetServiceCountQuery, GetServiceCountQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetServiceCountQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }

    public async Task<GetServiceCountQueryResult> Handle(GetServiceCountQuery request, CancellationToken cancellationToken)
    {
        return new GetServiceCountQueryResult
        {
            Count = _statisticRepository.GetServiceCount()
        }; 
    }
}
