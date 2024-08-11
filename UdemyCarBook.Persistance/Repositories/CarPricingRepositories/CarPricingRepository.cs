﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.CarPricingRepositories;
public class CarPricingRepository : ICarPricingRepository
{
	private readonly CarBookContext _context;

	public CarPricingRepository(CarBookContext context)
	{
		_context = context;
	}

	public List<CarPricing> GetCarPricingWithCar()
	{
		var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brands).Include(x => x.Pricing).Where(x => x.PricingID == 2).ToList();
		return values;
	}

	public List<GetCarPricingWithTimePeriodQueryResult> GetCarPricingWithTimePeriod()
	{
		var carPricings = _context.CarPricings
		   .GroupBy(x => new { x.Car.Model }) // CarName'i varsayıyorum
		   .Select(g => new GetCarPricingWithTimePeriodQueryResult
		   {
			   Model = g.Key.Model,
			   DailyAmount = g.Where(x => x.PricingID == 3).Sum(y => y.Amount),
			   WeeklyAmount = g.Where(x => x.PricingID == 4).Sum(y => y.Amount),
			   MontlyAmount = g.Where(x => x.PricingID == 5).Sum(y => y.Amount)
		   })
		   .ToList();

		return carPricings;
	}

}
