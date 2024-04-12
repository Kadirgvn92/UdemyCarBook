using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;
public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _SocialMediaRepository;

    public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> SocialMediaRepository)
    {
        _SocialMediaRepository = SocialMediaRepository;
    }

    public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var values = await _SocialMediaRepository.GetByIDAsync(request.SocialMediaID);
        values.Name = request.Name;
        values.Url = request.Url;
        values.SocialMediaID = request.SocialMediaID;
        values.Icon = request.Icon;
        await _SocialMediaRepository.UpdateAsync(values);
    }
}
