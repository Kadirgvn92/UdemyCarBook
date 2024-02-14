﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
public class GetCarWithBrandQueryHandler
{
    private readonly IRepository<Car> _carRepository;

    public GetCarWithBrandQueryHandler(IRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task<List<GetCarWithBrandQueryResult>> Handle()
    {
        var values = await _carRepository.GetAllAsync();
        return values.Select(x => new GetCarWithBrandQueryResult
        {
            BrandName = x.Brands.Name,
            BigImageUrl = x.BigImageUrl,
            BrandID = x.BrandID,
            CarID = x.CarID,
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
