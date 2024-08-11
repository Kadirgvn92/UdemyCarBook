using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.DTO.RentACarDTOs;
public class FilterRentACarDTO
{
    public int CarID { get; set; }
    public string Brand { get; set; }
    public string CoverImageUrl { get; set; }
    public string Model { get; set; }
    public decimal Amount { get; set; }
}
