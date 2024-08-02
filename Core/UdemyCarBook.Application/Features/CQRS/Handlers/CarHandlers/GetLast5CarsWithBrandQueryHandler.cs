using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
public class GetLast5CarsWithBrandQueryHandler
{
    private readonly ICarRepository _carRepository;
    public GetLast5CarsWithBrandQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public List<GetLast5CarsWithBrandQuery> Handle()
    {
        var values = _carRepository.GetLast5CarWithBrand();
        return values.Select(x => new GetLast5CarsWithBrandQuery
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
