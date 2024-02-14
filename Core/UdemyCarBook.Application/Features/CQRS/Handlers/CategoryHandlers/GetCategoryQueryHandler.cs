using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CategoryResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
public class GetCategoryQueryHandler
{
    private readonly IRepository<Category> _categoryRepository;

    public GetCategoryQueryHandler(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<List<GetCategoryQueryResult>> Handle()
    {
        var values = await _categoryRepository.GetAllAsync();
        return values.Select(x => new GetCategoryQueryResult
        {
            Name = x.Name,
            CategoryID = x.CategoryID,
        }).ToList(); ;
    }
}
