using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.BannerQueries;
using UdemyCarBook.Application.Features.CQRS.Results.BannerResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
public class GetBannerByIdQueryHandler
{
    private readonly IRepository<Banner> _bannerRepository;

    public GetBannerByIdQueryHandler(IRepository<Banner> bannerRepository)
    {
        _bannerRepository = bannerRepository;
    }
    public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
    {
        var values = await _bannerRepository.GetByIDAsync(query.Id);
        return new GetBannerByIdQueryResult
        {
            BannerID = values.BannerID,
            Description = values.Description,
            Title = values.Title,
            Video = values.Video,
            VideoDescription = values.VideoDescription
        };
    }
}
