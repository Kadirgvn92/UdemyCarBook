using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;
using UdemyCarBook.Application.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
public class GetBrandByIDQueryHandler
{
    private readonly IRepository<Brand> _repository;

    public GetBrandByIDQueryHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }
    public async Task<GetBrandByIDQueryResult> Handle(GetBrandByIDQuery query)
    {
        var values = await _repository.GetByIDAsync(query.ID);
        return new GetBrandByIDQueryResult
        {
            BrandID = values.BrandID,
            Name = values.Name
        };
    }
}
