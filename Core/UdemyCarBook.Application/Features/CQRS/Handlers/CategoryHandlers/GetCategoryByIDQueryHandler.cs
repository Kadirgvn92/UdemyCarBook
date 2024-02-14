using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.CategoryQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CategoryResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
public class GetCategoryByIDQueryHandler
{
    private readonly IRepository<Category> _categoryRepository;

    public GetCategoryByIDQueryHandler(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<GetCategoryByIDQueryResult> Handle(GetCategoryByIDQuery query) 
    {
        var values = await _categoryRepository.GetByIDAsync(query.ID);
        return new GetCategoryByIDQueryResult
        {
            CategoryID = values.CategoryID,
            Name = values.Name
        };
    }
}
