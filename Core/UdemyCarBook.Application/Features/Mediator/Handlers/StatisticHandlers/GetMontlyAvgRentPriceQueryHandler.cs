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
public class GetMontlyAvgRentPriceQueryHandler : IRequestHandler<GetMontlyAvgRentPriceQuery, GetMonylyAvgRentPriceQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetMontlyAvgRentPriceQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }

    public async Task<GetMonylyAvgRentPriceQueryResult> Handle(GetMontlyAvgRentPriceQuery request, CancellationToken cancellationToken)
    {
        return new GetMonylyAvgRentPriceQueryResult
        {
            Price = _statisticRepository.GetMontlyAvgRentPrice()
        };
    }
}
