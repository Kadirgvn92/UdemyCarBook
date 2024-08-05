using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;
public class RemoveTagCloudCommandHandler : IRequestHandler<RemoveTagCloudCommand>
{
    private readonly IRepository<TagCloud> _TagCloudRepository;

    public RemoveTagCloudCommandHandler(IRepository<TagCloud> TagCloudRepository)
    {
        _TagCloudRepository = TagCloudRepository;
    }

    public async Task Handle(RemoveTagCloudCommand request, CancellationToken cancellationToken)
    {
        var values = await _TagCloudRepository.GetByIDAsync(request.Id);
        await _TagCloudRepository.DeleteAsync(values);
    }
}
