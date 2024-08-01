using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.AuhtorCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers;
public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
{
    private readonly IRepository<Author> _authorRepository;

    public UpdateAuthorCommandHandler(IRepository<Author> authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var values = await _authorRepository.GetByIDAsync(request.AuthorID);
        values.Description = request.Description;
        values.Name = request.Name;
        values.ImageUrl = request.ImageUrl;
        await _authorRepository.UpdateAsync(values);
    }
}
