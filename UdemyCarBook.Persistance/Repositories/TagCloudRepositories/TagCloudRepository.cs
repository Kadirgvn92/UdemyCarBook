using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.TagCloudRepositories;
public class TagCloudRepository : ITagCloudRepository
{
    private readonly CarBookContext _carBookContext;

    public TagCloudRepository(CarBookContext carBookContext)
    {
        _carBookContext = carBookContext;
    }

    public List<TagCloud> GetTagCloudByBlogId(int id)
    {
        var values = _carBookContext.TagClouds.Where(c => c.BlogID == id).ToList(); 
        return values;  
    }
}
