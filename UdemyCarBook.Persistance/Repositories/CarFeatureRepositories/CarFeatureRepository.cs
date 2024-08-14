using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.CarFeatureRepositories;
public class CarFeatureRepository : ICarFeatureRepository
{
    private readonly CarBookContext _context;

    public CarFeatureRepository(CarBookContext context)
    {
        _context = context;
    }

    public void ChangeCarFeatureAvailableToFalse(int id)
    {
       var values = _context.CarFeatures.Where(x => x.CarFeatureID  == id).FirstOrDefault();
        values.Available = false;
        _context.CarFeatures.Update(values);
       _context.SaveChanges();
    }

    public void ChangeCarFeatureAvailableToTrue(int id)
    {
        var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
        values.Available = true;

        _context.CarFeatures.Update(values);
        _context.SaveChanges();
    }

    public void CreateCarFeatureByCar(CarFeature carFeature)
    {
        _context.CarFeatures.Add(carFeature);
        _context.SaveChanges();

    }

    public List<CarFeature> GetCarFeaturesByCarID(int id)
    {
        var values = _context.CarFeatures.Include(y => y.Feature).Where(x => x.CarID == id).ToList();   
        return values;
    }
}
