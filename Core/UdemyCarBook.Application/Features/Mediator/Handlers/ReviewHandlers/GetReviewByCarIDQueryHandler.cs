using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.ReviewQueries;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers;
public class GetReviewByCarIDQueryHandler : IRequestHandler<GetReviewByCarIDQuery, List<GetReviewByCarIDQueryResult>>
{
    private readonly IReviewRepository _reviewRepository;

    public GetReviewByCarIDQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<List<GetReviewByCarIDQueryResult>> Handle(GetReviewByCarIDQuery request, CancellationToken cancellationToken)
    {
        var values = _reviewRepository.GetReviewsByCarID(request.Id);
        return values.Select(x => new GetReviewByCarIDQueryResult
        {
            CarID = x.CarID,
            Comment = x.Comment,
            CustomerImage = x.CustomerImage,
            CustomerName = x.CustomerName,
            RatingValue = x.RatingValue,
            ReviewDate = x.ReviewDate,
            ReviewID  = x.ReviewID,
        }).ToList();
    }
}
