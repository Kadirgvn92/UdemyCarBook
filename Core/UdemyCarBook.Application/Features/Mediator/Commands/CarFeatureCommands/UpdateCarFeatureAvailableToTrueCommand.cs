using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
public class UpdateCarFeatureAvailableToTrueCommand : IRequest
{
    public int Id { get; set; }

    public UpdateCarFeatureAvailableToTrueCommand(int id)
    {
        Id = id;
    }
}
