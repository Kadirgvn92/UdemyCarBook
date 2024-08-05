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
public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
{
    private readonly IRepository<Blog> _blogRepository;

    public GetBlogByIdQueryHandler(IRepository<Blog> blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _blogRepository.GetByIDAsync(request.Id);
        return new GetBlogByIdQueryResult
        {
           CreatedDate = values.CreatedDate,
           AuthorID = values.AuthorID,
           Title = values.Title,
           CoverImageUrl = values.CoverImageUrl,
           CategoryID = values.CategoryID,
           BlogID = values.BlogID,
           Description = values.Description,
        };
    }
}
