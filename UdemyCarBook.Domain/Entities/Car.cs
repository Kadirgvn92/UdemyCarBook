using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities;
public class Car
{
    public Guid CarID { get; set; }
    public Guid BrandID { get; set; }
    public Brand Brand { get; set; }
    public string Model { get; set; }
    public string CoverImageUrl { get; set; }
    public int Km { get; set; }
    public string Transmission { get; set; }
    public short Seats { get; set; }
    public short Luggage { get; set; }
    public string Fuel { get; set; }
    public string BigImageUrl { get; set; }
}
