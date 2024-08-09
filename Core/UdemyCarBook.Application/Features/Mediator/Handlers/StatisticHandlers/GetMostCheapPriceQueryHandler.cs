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
public class GetMostCheapPriceQueryHandler : IRequestHandler<GetMostCheapPriceQuery, GetMostCheapPriceQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetMostCheapPriceQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }

    public async Task<GetMostCheapPriceQueryResult> Handle(GetMostCheapPriceQuery request, CancellationToken cancellationToken)
    {
        return new GetMostCheapPriceQueryResult
        {
            Price = _statisticRepository.GetMostCheapPrice()
        };
    }
}
