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

    public int GetCarCount()
    {
        var values = _context.Cars.Count();
        return values;
    }

    public List<Car> GetCarsListWithBrand()
    {
        var values = _context.Cars.Include(x => x.Brands).ToList();
        return values;
    }

	public Car GetCarWithBrandByID(int id)
	{
		var values = _context.Cars.Include(x => x.Brands).Where(x => x.CarID == id).FirstOrDefault();
		return values;
	}

	public List<Car> GetLast5CarWithBrand()
    {
        var values = _context.Cars.Include(x => x.Brands).OrderByDescending(x => x.CarID).Take(5).ToList();
        return values;  
    }
}
