using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Interfaces.StatisticInterfaces;
public interface IStatisticRepository
{
    int GetLocationCount();
    int GetAuhtorCount();
    int GetBlogCount();
    int GetPricingCount();
    int GetCarFeatureCount();
    int GetMostExpensivePrice();
    int GetWeeklyAvgRentPrice();
    int GetMostCheapPrice();
    string GetMostExpensiveCar();
    string GetMostCheapCar();
    int GetTestimonialCount();
    int GetDailyAvgRentPrice();
    int GetHourlyAvgRentPrice();
    int GetMontlyAvgRentPrice();
    int GetServiceCount();
}
