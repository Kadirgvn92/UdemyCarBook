using MediatR;

namespace UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
public class UpdateCarFeatureAvailableToFalseCommand : IRequest
{
    public int Id { get; set; }

    public UpdateCarFeatureAvailableToFalseCommand(int id)
    {
        Id = id;
    }
}
