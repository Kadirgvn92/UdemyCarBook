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
public class GetMostExpensivePriceQueryHandler : IRequestHandler<GetMostExpensivePriceQuery, GetMostExpensivePriceQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetMostExpensivePriceQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }

    public async Task<GetMostExpensivePriceQueryResult> Handle(GetMostExpensivePriceQuery request, CancellationToken cancellationToken)
    {
        return new GetMostExpensivePriceQueryResult
        {
            Price = _statisticRepository.GetMostExpensivePrice()
        };
    }
}
