using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
public class GetAboutByIdQueryHandler
{
    private readonly IRepository<About> _aboutRepository;

    public GetAboutByIdQueryHandler(IRepository<About> aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }
    public async Task<GetBannertByIdQueryResult> Handle(GetAboutByIdQuery query)
    {
        var values = await _aboutRepository.GetByIDAsync(query.Id);
        return new GetBannertByIdQueryResult
        {
            AboutID = values.AboutID,
            Description = values.Description,
            ImageUrl = values.ImageUrl,
            Title = values.Title
        };
    }
}
