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
public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand>
{
    private readonly IRepository<TagCloud> _TagCloudRepository;

    public CreateTagCloudCommandHandler(IRepository<TagCloud> TagCloudRepository)
    {
        _TagCloudRepository = TagCloudRepository;
    }

    public async Task Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
    {
        await _TagCloudRepository.CreateAsync(new TagCloud
        {
            BlogID = request.BlogID,
            Title = request.Title,  
            
        });
    }
}
