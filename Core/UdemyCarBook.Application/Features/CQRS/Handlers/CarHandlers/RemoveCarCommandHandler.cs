using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
public class RemoveCarCommandHandler
{
    private readonly IRepository<Car> _carRepository;

    public RemoveCarCommandHandler(IRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task Handle(RemoveCarCommand command)
    {
        var values = await _carRepository.GetByIDAsync(command.ID);
        await _carRepository.DeleteAsync(values);
    }
}
