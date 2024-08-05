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
public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, GetBlogByAuthorIdQueryResult>
{
    private readonly IBlogRepository _blogRepository;

    public GetBlogByAuthorIdQueryHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<GetBlogByAuthorIdQueryResult> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
    {
        var values = _blogRepository.GetBlogByAuthorId(request.Id);
        return new GetBlogByAuthorIdQueryResult
        {
            AuthorID = values.AuthorID,
            BlogID = values.BlogID,
            CategoryID = values.CategoryID,
            CoverImageUrl = values.CoverImageUrl,
            CreatedDate = values.CreatedDate,
            Title = values.Title,
            AuthorName = values.Author.Name,
            CategoryName = values.Category.Name,
            Description = values.Description,
            AuthorDescription = values.Author.Description,
            AuthorImageUrl = values.Author.ImageUrl,
        };
    }
}
