using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;
public class GetTagCloudByIdQuery : IRequest<GetTagCloudByIdQueryResult>
{
    public int ID { get; set; }

    public GetTagCloudByIdQuery(int iD)
    {
        ID = iD;
    }
}
