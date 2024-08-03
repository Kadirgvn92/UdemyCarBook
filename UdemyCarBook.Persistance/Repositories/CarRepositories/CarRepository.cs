using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.CarRepositories;
public class CarRepository : ICarRepository
{
    private readonly CarBookContext _context;

    public CarRepository(CarBookContext context)
    {
        _context = context;
    }

    public List<Car> GetCarsListWithBrand()
    {
        var values = _context.Cars.Include(x => x.Brands).ToList();
        return values;
    }

	public List<CarPricing> GetCarsWithPricings()
	{
        var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brands).Include(x => x.Pricing).ToList();
        return values;
	}

	public List<Car> GetLast5CarWithBrand()
    {
        var values = _context.Cars.Include(x => x.Brands).OrderByDescending(x => x.CarID).Take(5).ToList();
        return values;  
    }
}
