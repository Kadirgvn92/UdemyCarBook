using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;
public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
{
    private readonly ITagCloudRepository _tagCloudRepository;

    public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository tagCloudRepository)
    {
        _tagCloudRepository = tagCloudRepository;
    }

    public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
    {
        var values = _tagCloudRepository.GetTagCloudByBlogId(request.Id);
        return values.Select(x => new GetTagCloudByBlogIdQueryResult
        {
            Title = x.Title,
            BlogID = x.BlogID,
            TagCloudID = x.TagCloudID,
        }).ToList();
    }
}
