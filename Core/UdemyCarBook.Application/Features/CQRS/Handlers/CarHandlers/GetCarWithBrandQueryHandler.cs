using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
public class GetCarWithBrandQueryHandler
{
    private readonly ICarRepository _carRepository;

    public GetCarWithBrandQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public List<GetCarWithBrandQueryResult> Handle()
    {
        var values = _carRepository.GetCarsListWithBrand();
        return values.Select(x => new GetCarWithBrandQueryResult
        {
            CarID = x.CarID,
            BrandID = x.BrandID,
            BrandName = x.Brands.Name,
            BigImageUrl = x.BigImageUrl,
            CoverImageUrl = x.CoverImageUrl,
            Fuel = x.Fuel,
            Km = x.Km,
            Luggage = x.Luggage,
            Model = x.Model,
            Seats = x.Seats,
            Transmission = x.Transmission
        }).ToList();
    }
}
