using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;
public class GetCarPricingWithTimePeriodQueryResult
{
    public int CarID { get; set; }
    public string Model { get; set; }
    public string BrandName { get; set; }
    public string CoverImageUrl { get; set; }
    public decimal DailyAmount { get; set; }
    public decimal WeeklyAmount { get; set; }
    public decimal MontlyAmount { get; set; }
}
