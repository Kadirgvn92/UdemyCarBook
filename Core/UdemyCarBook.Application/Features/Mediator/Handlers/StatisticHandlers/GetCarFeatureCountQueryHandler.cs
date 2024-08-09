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
public class GetCarFeatureCountQueryHandler : IRequestHandler<GetCarFeatureCountQuery, GetCarFeatureCountQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetCarFeatureCountQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }

    public async Task<GetCarFeatureCountQueryResult> Handle(GetCarFeatureCountQuery request, CancellationToken cancellationToken)
    {
        return new GetCarFeatureCountQueryResult
        {
            Count = _statisticRepository.GetCarFeatureCount()
        };
    }
}
