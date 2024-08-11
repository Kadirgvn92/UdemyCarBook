using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.DTO.CarPricingDTOs;
public class ResultCarPricingWithTime
{
    public string Model { get; set; }
    public decimal DailyAmount { get; set; }
    public decimal WeeklyAmount { get; set; }
    public decimal MontlyAmount { get; set; }
}
