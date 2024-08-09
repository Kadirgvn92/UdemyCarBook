using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.StatisticInterfaces;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.StatisticRepository;
public class StatisticRepository : IStatisticRepository
{
    private readonly CarBookContext _context;

    public StatisticRepository(CarBookContext context)
    {
        _context = context;
    }

    public int GetAuhtorCount()
    {
        var values = _context.Authors.Count();
        return values;
    }

    public int GetWeeklyAvgRentPrice()
    {
        var values = _context.CarPricings.Where(x => x.PricingID == 4).Select(x => x.Amount).Average();
        return Convert.ToInt32(values);
    }

    public int GetBlogCount()
    {
        var values = _context.Blogs.Count();
        return values;
    }

    public int GetCarFeatureCount()
    {
        var values = _context.Features.Count();
        return values;
    }

    public int GetDailyAvgRentPrice()
    {
        var values = _context.CarPricings.Where(x => x.PricingID == 3).Select(x => x.Amount).Average();
        return Convert.ToInt32(values);
    }

    public int GetHourlyAvgRentPrice()
    {
        var values = _context.CarPricings.Where(x => x.PricingID == 2).Select(x => x.Amount).Average();
        return Convert.ToInt32(values);
    }

    public int GetLocationCount()
    {
      var values = _context.Locations.Count();
        return values;
    }

    public int GetMontlyAvgRentPrice()
    {
        var values = _context.CarPricings.Where(x => x.PricingID == 5).Select(x => x.Amount).Average();
        return Convert.ToInt32(values);
    }

    public string GetMostCheapCar()
    {
        var minAmountCarID = _context.CarPricings
      .OrderBy(x => x.Amount)
      .Select(x => x.CarID)
      .FirstOrDefault();

        var carBrand = _context.Cars.Include(x => x.Brands).Where(x => x.CarID == minAmountCarID).FirstOrDefault().Brands.Name; 
        var model  = _context.Cars.Include(x => x.Brands).Where(x => x.CarID == minAmountCarID).FirstOrDefault().Model; 
        var values = carBrand + " " + model;  
        return values;

    }

    public int GetMostCheapPrice()
    {
        var values = _context.CarPricings.OrderBy(x => x.Amount).Select(x => x.Amount).FirstOrDefault();
        return Convert.ToInt32(values);
    }

    public string GetMostExpensiveCar()
    {
        var maxAmountCarID = _context.CarPricings.OrderByDescending(x => x.Amount).Select(x => x.CarID).FirstOrDefault();

        var carBrand = _context.Cars.Include(x => x.Brands).Where(x => x.CarID == maxAmountCarID).FirstOrDefault().Brands.Name;
        var model = _context.Cars.Include(x => x.Brands).Where(x => x.CarID == maxAmountCarID).FirstOrDefault().Model;
        var values = carBrand + " " + model;
        return values;
    }

    public int GetMostExpensivePrice()
    {
        var values = _context.CarPricings.OrderByDescending(x => x.Amount).Select(x => x.Amount).FirstOrDefault();
        return Convert.ToInt32(values);
    }

    public int GetPricingCount()
    {
        var values = _context.Pricings.Count();
        return values;
    }

    public int GetTestimonialCount()
    {
        var values = _context.Testimonials.Count();
        return values;
    }

    public int GetServiceCount()
    {
        var values = _context.Services.Count();
        return values;
    }
}
