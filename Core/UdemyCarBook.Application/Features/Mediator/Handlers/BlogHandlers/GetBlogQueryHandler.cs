using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResult;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers;
public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
{
    private readonly IRepository<Blog> _blogRepository;

    public GetBlogQueryHandler(IRepository<Blog> blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        var values =  await _blogRepository.GetAllAsync();
        return values.Select(x => new GetBlogQueryResult
        {
            AuthorID = x.AuthorID,
            BlogID = x.BlogID,
            CategoryID = x.CategoryID,
            CoverImageUrl = x.CoverImageUrl,
            CreatedDate = x.CreatedDate,
            Title = x.Title
        }).ToList();
    }
}
