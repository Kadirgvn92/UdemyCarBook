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
public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
{
    private readonly IRepository<TagCloud> _TagCloudRepository;

    public UpdateTagCloudCommandHandler(IRepository<TagCloud> TagCloudRepository)
    {
        _TagCloudRepository = TagCloudRepository;
    }

    public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
    {
        var values = await _TagCloudRepository.GetByIDAsync(request.TagCloudID);
        values.Title = request.Title;
        values.BlogID = request.BlogID;

        await _TagCloudRepository.UpdateAsync(values);
    }
}
