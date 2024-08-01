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
public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
{
    private readonly IRepository<Author> _repository;

    public RemoveAuthorCommandHandler(IRepository<Author> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIDAsync(request.Id);
        await _repository.DeleteAsync(values);
    }
}
