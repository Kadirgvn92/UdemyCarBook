using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;
public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
{
    private readonly IRepository<TagCloud> _TagCloudRepository;

    public GetTagCloudQueryHandler(IRepository<TagCloud> TagCloudRepository)
    {
        _TagCloudRepository = TagCloudRepository;
    }

    public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
    {
        var values = await _TagCloudRepository.GetAllAsync();
        return values.Select(x => new GetTagCloudQueryResult
        {
           Title = x.Title,
           BlogID = x.BlogID,
           TagCloudID = x.TagCloudID,
        }).ToList();
    }
}
