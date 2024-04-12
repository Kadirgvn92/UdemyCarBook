using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
public class GetSocialMediaByIdQueryResult : IRequest<GetSocialMediaByIdQueryResult>
{
    public int Id { get; set; }

    public GetSocialMediaByIdQueryResult(int id)
    {
        Id = id;
    }
}
