using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly IGenericRepository<Comment> _repository;

    public CommentController(IGenericRepository<Comment> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public IActionResult CommentList()
    {
        var values = _repository.GetAll();
        return Ok(values);
    }
}
