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

    public List<CarFeature> GetCarFeaturesByCarID(int id)
    {
        var values = _context.CarFeatures.Where(x => x.CarID == id).ToList();   
        return values;
    }
}
