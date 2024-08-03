﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.CarPricingRepositories;
public  class CarPricingRepository
{
	private readonly CarBookContext _context;

	public CarPricingRepository(CarBookContext context)
	{
		_context = context;
	}

	public List<CarPricing> GetCarsWithPricings()
	{
		var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brands).Include(x => x.Pricing).ToList();
		return values;
	}
}
