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
public class GetHourlyAvgRentPriceQueryHandler : IRequestHandler<GetHourlyAvgRentPriceQuery, GetHourlyAvgRentPriceQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetHourlyAvgRentPriceQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }

    public async Task<GetHourlyAvgRentPriceQueryResult> Handle(GetHourlyAvgRentPriceQuery request, CancellationToken cancellationToken)
    {
        return new GetHourlyAvgRentPriceQueryResult
        {
            Price = _statisticRepository.GetHourlyAvgRentPrice()
        };
    }
}
