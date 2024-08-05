using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers;
public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
{
    private readonly IBlogRepository _blogRepository;

    public GetBlogByAuthorIdQueryHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
    {
        var values = _blogRepository.GetBlogByAuthorId(request.Id);
        return values.Select(x => new GetBlogByAuthorIdQueryResult
        {
            AuthorID = x.AuthorID,
            BlogID = x.BlogID,
            CategoryID = x.CategoryID,
            CoverImageUrl = x.CoverImageUrl,
            CreatedDate = x.CreatedDate,
            Title = x.Title,
            AuthorName = x.Author.Name,
            CategoryName = x.Category.Name,
            Description = x.Description,
            AuthorDescription = x.Author.Description,
            AuthorImageUrl = x.Author.ImageUrl,
        }).ToList();
    }
}
