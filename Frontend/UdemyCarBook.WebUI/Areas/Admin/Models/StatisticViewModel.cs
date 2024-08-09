using UdemyCarBook.DTO.StatisticDTOs;

namespace UdemyCarBook.WebUI.Areas.Admin.Models;

public class StatisticViewModel
{
    public ResultStatisticCarDTO ExpensiveCar { get; set; }
    public ResultStatisticCarDTO CheapCar { get; set; }
    public ResultStatisticCountDTO CarCount { get; set; }
    public ResultStatisticCountDTO LocationCount { get; set; }
    public ResultStatisticCountDTO AuthorCount { get; set; }
    public ResultStatisticCountDTO BlogCount { get; set; }
    public ResultStatisticCountDTO PricingCount { get; set; }
    public ResultStatisticCountDTO CarFeatureCount { get; set; }
    public ResultStatisticCountDTO TestimonialCount { get; set; }
    public ResultStatisticPriceDTO MostExpensivePrice { get; set; }
    public ResultStatisticPriceDTO MostCheapPrice { get; set; }
    public ResultStatisticPriceDTO WeeklyAvgRentPrice { get; set; }
    public ResultStatisticPriceDTO HourlyAvgRentPrice { get; set; }
    public ResultStatisticPriceDTO DailyAvgRentPrice { get; set; }
    public ResultStatisticPriceDTO MontlyAvgRentPrice { get; set; }
    public ResultStatisticCountDTO ServiceCount { get; set; }
}
