using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
public class GetCarByIDQueryHandler
{
    private readonly IRepository<Car> _carRepository;

    public GetCarByIDQueryHandler(IRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task<GetCarByIDQueryResult> Handle(GetCarByIDQuery query)
    {
        var values = await _carRepository.GetByIDAsync(query.ID);
        return new GetCarByIDQueryResult
        {
            BigImageUrl = values.BigImageUrl,
            BrandID = values.BrandID,
            CarID = values.CarID,
            CoverImageUrl = values.CoverImageUrl,
            Fuel = values.Fuel,
            Km = values.Km,
            Luggage = values.Luggage,
            Model = values.Model,
            Seats = values.Seats,
            Transmission = values.Transmission
        };
    }
}
