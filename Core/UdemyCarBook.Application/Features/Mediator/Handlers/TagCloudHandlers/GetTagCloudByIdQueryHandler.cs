using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAddressResult;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;
public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
{
    private readonly IRepository<TagCloud> _TagCloudRepository;

    public GetTagCloudByIdQueryHandler(IRepository<TagCloud> TagCloudRepository)
    {
        _TagCloudRepository = TagCloudRepository;
    }

    public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _TagCloudRepository.GetByIDAsync(request.ID);
        return new GetTagCloudByIdQueryResult
        {
            TagCloudID = values.TagCloudID,
            Title = values.Title,   
        };
    }

}
