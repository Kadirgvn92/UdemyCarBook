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
public class GetMostCheapCarQueryHandler : IRequestHandler<GetMostCheapCarQuery, GetMostCheapCarQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetMostCheapCarQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }

    public async Task<GetMostCheapCarQueryResult> Handle(GetMostCheapCarQuery request, CancellationToken cancellationToken)
    {
        return new GetMostCheapCarQueryResult
        {
            Car = _statisticRepository.GetMostCheapCar()
        };
    }
}
