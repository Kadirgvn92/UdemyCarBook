using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers;
public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
{
    private readonly IRepository<Blog> _blogRepository;

    public UpdateBlogCommandHandler(IRepository<Blog> blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var values = await _blogRepository.GetByIDAsync(request.BlogID);
        values.AuthorID = request.AuthorID;
        values.Title = request.Title;
        values.CategoryID = request.CategoryID;
        values.CoverImageUrl = request.CoverImageUrl;
        values.CreatedDate = request.CreatedDate;
        values.Description = request.Description;
        await _blogRepository.UpdateAsync(values);
    }
}
