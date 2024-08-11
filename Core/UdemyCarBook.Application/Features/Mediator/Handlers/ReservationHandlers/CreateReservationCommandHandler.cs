using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReservationHandlers;
public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
{
    private readonly IRepository<Reservation> _reservationRepository;

    public CreateReservationCommandHandler(IRepository<Reservation> reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        await _reservationRepository.CreateAsync(new Reservation
        {
            Age = request.Age,
            Description = request.Description,
            DriverLicenceYear = request.DriverLicenceYear,
            DropofLocationID = request.DropofLocationID,
            Mail = request.Mail,
            Name = request.Name,
            Phone = request.Phone,
            PickUpLocationID = request.PickUpLocationID,
            CarID = request.CarID,
            Status = "Rezervasyon Alındı"
        });
    }
}
