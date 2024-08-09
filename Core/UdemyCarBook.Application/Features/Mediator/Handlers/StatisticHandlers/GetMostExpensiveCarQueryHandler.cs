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
public class GetMostExpensiveCarQueryHandler : IRequestHandler<GetMostExpensiveCarQuery, GetMostExpensiveCarQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetMostExpensiveCarQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }

    public async Task<GetMostExpensiveCarQueryResult> Handle(GetMostExpensiveCarQuery request, CancellationToken cancellationToken)
    {
        return new GetMostExpensiveCarQueryResult
        {
            Car = _statisticRepository.GetMostExpensiveCar()
        };
    }
}
