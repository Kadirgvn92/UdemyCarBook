using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.ReviewRepositories;
public class ReviewRepository : IReviewRepository
{
    private readonly CarBookContext _carBookContext;

    public ReviewRepository(CarBookContext carBookContext)
    {
        _carBookContext = carBookContext;
    }

    public List<Review> GetReviewsByCarID(int id)
    {
      var values = _carBookContext.Review.Include(x => x.Car).Where(x => x.CarID == id).ToList();
        return values;  
    }
}
