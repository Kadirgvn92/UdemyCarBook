using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.DTO.CarDTOs;
using UdemyCarBook.DTO.CarPricingDTOs;
using UdemyCarBook.DTO.LocationDTOs;

namespace UdemyCarBook.DTO;
public class ResultDTO
{
    public ResultCarDTO  ResultCars { get; set; }
    public ResultLocationDTO Locations { get; set; }
}
