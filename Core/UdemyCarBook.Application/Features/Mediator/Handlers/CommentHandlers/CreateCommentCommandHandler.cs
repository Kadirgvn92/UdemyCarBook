using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CommentHandlers;
public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
{
    private readonly IRepository<Comment> _commentRepository;

    public CreateCommentCommandHandler(IRepository<Comment> commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        await _commentRepository.CreateAsync(new Comment
        {
            Name = request.Name,
            CreatedDate = DateTime.Now,
            Description = request.Description,
            IsApproved = request.IsApproved,
            Mail = request.Mail,
            BlogID = request.BlogID,
            
        });
    }
}
