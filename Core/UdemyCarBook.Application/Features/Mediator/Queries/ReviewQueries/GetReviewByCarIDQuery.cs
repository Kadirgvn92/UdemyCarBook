using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.ReviewQueries;
public class GetReviewByCarIDQuery : IRequest<List<GetReviewByCarIDQueryResult>>
{
    public int Id { get; set; }

    public GetReviewByCarIDQuery(int id)
    {
        Id = id;
    }
}
