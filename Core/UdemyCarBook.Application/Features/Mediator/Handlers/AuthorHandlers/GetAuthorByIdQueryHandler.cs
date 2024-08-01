using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AuthorResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers;
public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
{
    private readonly IRepository<Author> _authorRepository;

    public GetAuthorByIdQueryHandler(IRepository<Author> authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _authorRepository.GetByIDAsync(request.Id);
        return new GetAuthorByIdQueryResult
        {
            AuthorID = values.AuthorID,
            Description = values.Description,
            ImageUrl = values.ImageUrl,
            Name = values.Name,
        };
    }
}
