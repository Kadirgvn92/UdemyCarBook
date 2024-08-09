﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
using UdemyCarBook.Application.Interfaces.StatisticInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticHandlers;
public class GetWeeklyAvgRentPriceQueryHandler : IRequestHandler<GetWeeklyAvgRentPriceQuery, GetWeeklyAvgRentPriceQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetWeeklyAvgRentPriceQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }

    public async Task<GetWeeklyAvgRentPriceQueryResult> Handle(GetWeeklyAvgRentPriceQuery request, CancellationToken cancellationToken)
    {
        return new GetWeeklyAvgRentPriceQueryResult
        {
            Price = _statisticRepository.GetWeeklyAvgRentPrice()
        };
    }
}
