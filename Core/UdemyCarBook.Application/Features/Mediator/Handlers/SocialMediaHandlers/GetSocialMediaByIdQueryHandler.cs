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
public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
{
    private readonly IRepository<SocialMedia> _SocialMediaRepository;

    public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> SocialMediaRepository)
    {
        _SocialMediaRepository = SocialMediaRepository;
    }

    public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _SocialMediaRepository.GetByIDAsync(request.Id);
        return new GetSocialMediaByIdQueryResult
        {
            Icon = values.Icon,
            SocialMediaID = values.SocialMediaID,
            Name = values.Name,
            Url = values.Url    
        };
    }
}
