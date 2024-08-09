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
public class GetPricingCountQueryHandler : IRequestHandler<GetPricingCountQuery, GetPricingCountQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetPricingCountQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }

    public async Task<GetPricingCountQueryResult> Handle(GetPricingCountQuery request, CancellationToken cancellationToken)
    {
        return new GetPricingCountQueryResult
        {
            Count = _statisticRepository.GetPricingCount()
        };
    }
}
