﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
public class CreateCarCommandHandler
{
    private readonly IRepository<Car> _repositories;

    public CreateCarCommandHandler(IRepository<Car> repositories)
    {
        _repositories = repositories;
    }
    public async Task Handle(CreateCarCommand command)
    {
        await _repositories.CreateAsync(new Car
        {
            BigImageUrl = command.BigImageUrl,
            BrandID = command.BrandID,
            CoverImageUrl = command.CoverImageUrl,
            Fuel = command.Fuel,
            Km = command.Km,
            Luggage = command.Luggage,
            Model = command.Model,
            Seats = command.Seats,
            Transmission = command.Transmission
        });
    }
}
