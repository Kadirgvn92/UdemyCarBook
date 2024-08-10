using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities;
public class RentACarProcess
{
    public int RentACarProcessID { get; set; }
    public int CarID { get; set; }
    public Car Car { get; set; }
    public int PickUpLocation { get; set; }
    public int DropOfLocation { get; set; }
    public DateTime PickUpDate { get; set; }
    public DateTime DropOfDate { get; set; }
    public TimeSpan PickUpTime { get; set; }
    public TimeSpan DropOfTime { get; set; }
    public int CustomerID { get; set; }
    public Customer Customer { get; set; }
    public string PickUpDescription { get; set; }
    public string DropOfDescription { get; set; }
    public decimal TotalPrice { get; set; }
}
