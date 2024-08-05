using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.BlogRepositories;
public class BlogRepositories : IBlogRepository
{
    private readonly CarBookContext _context;

    public BlogRepositories(CarBookContext context)
    {
        _context = context;
    }

    public List<Blog> GetAllBlogsWithAuthors()
    {
        var values = _context.Blogs.Include(x => x.Author).Include(x => x.Category).ToList();
        return values;
    }

    public Blog GetBlogByAuthorId(int id)
    {
        var values = _context.Blogs.Include(x => x.Author).Include(x => x.Category).Where(x => x.BlogID == id).FirstOrDefault();
        return values;
    }

    public List<Blog> GetLast3BlogsWithAuthors()
    {
        var values = _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToList();
        return values;
    }
}
