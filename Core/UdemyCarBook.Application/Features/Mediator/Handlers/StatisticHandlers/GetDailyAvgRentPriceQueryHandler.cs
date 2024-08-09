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
public class GetDailyAvgRentPriceQueryHandler : IRequestHandler<GetDailyAvgRentPriceQuery, GetDailyAvgRentPriceQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetDailyAvgRentPriceQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }

    public async Task<GetDailyAvgRentPriceQueryResult> Handle(GetDailyAvgRentPriceQuery request, CancellationToken cancellationToken)
    {
        return new GetDailyAvgRentPriceQueryResult
        {
            Price = _statisticRepository.GetDailyAvgRentPrice()
        };
    }
}
