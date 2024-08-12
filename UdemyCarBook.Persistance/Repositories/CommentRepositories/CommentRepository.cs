using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.DTO.CommentDTO;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.CommentRepositories;
public class CommentRepository<T> : IGenericRepository<Comment>
{
    private readonly CarBookContext _carBookContext;

    public CommentRepository(CarBookContext carBookContext)
    {
        _carBookContext = carBookContext;
    }

    public void Add(Comment item)
    {
       _carBookContext.Comments.Add(item);
        _carBookContext.SaveChanges();
    }

    public List<Comment> GetAll()
    {
      var values = _carBookContext.Comments.ToList();
        return values.Select(x => new Comment
        {
            BlogID = x.BlogID,
            CommentId = x.CommentId,
            CreatedDate = x.CreatedDate,
            Description = x.Description,
            Name = x.Name,
            Mail = x.Mail,
            IsApproved = x.IsApproved,
        }).ToList();
    }

    public Comment GetById(int id)
    {
        var values = _carBookContext.Comments.FirstOrDefault(x => x.CommentId == id);
        return values;
    }

    public List<Comment> GetCommentsByBlogId(int id)
    {
      return _carBookContext.Set<Comment>().Where(x => x.BlogID == id).ToList();    

    }

    public void Remove(Comment item)
    {
        _carBookContext.Comments.Remove(item);
        _carBookContext.SaveChanges();
    }

    public void Update(Comment item)
    {
       _carBookContext.Comments.Update(item);
        _carBookContext.SaveChanges();
    }

    public int GetCountCommentByBlog(int id)
    {
        return _carBookContext.Comments.Where(x => x.BlogID == id && x.IsApproved == true).Count(); 
    }

    public async Task<Comment> GetCommentByIdAsync(int commentId)
    {
        return await _carBookContext.Comments.FindAsync(commentId);
    }

    public async Task UpdateApprovalAsync(int commentId, bool isApproved)
    {
        var comment = await _carBookContext.Comments.FindAsync(commentId);
        if (comment != null)
        {
            comment.IsApproved = isApproved;
            _carBookContext.Entry(comment).State = EntityState.Modified;
            await _carBookContext.SaveChangesAsync();
        }
    }
}
