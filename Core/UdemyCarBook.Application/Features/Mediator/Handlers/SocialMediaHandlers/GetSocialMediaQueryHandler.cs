using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAddressResult;
using UdemyCarBook.Application.Features.Mediator.Results.SocialMediaResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;
public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
{
    private readonly IRepository<SocialMedia> _SocialMediaRepository;

    public GetSocialMediaQueryHandler(IRepository<SocialMedia> SocialMediaRepository)
    {
        _SocialMediaRepository = SocialMediaRepository;
    }

    public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
    {
        var values = await _SocialMediaRepository.GetAllAsync();
        return values.Select(x => new GetSocialMediaQueryResult
        {
            Icon = x.Icon,
            Url = x.Url,
            Name = x.Name,
            SocialMediaID = x.SocialMediaID
        }).ToList();
    }
}
