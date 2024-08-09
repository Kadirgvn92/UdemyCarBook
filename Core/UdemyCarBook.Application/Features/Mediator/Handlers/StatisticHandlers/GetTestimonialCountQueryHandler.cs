using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Application.Interfaces.StatisticInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticHandlers;
public class GetTestimonialCountQueryHandler : IRequestHandler<GetTestimonialCountQuery, GetTestimonialCountQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetTestimonialCountQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }

    public async Task<GetTestimonialCountQueryResult> Handle(GetTestimonialCountQuery request, CancellationToken cancellationToken)
    {
        return new GetTestimonialCountQueryResult
        {
            Count = _statisticRepository.GetTestimonialCount()
        };
    }
}
