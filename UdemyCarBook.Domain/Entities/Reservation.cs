﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities;
public class Reservation
{
    public int ReservationID { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public int CarID { get; set; }
    public int? PickUpLocationID { get; set; }
    public int? DropofLocationID { get; set; }
    public int Age { get; set; }
    public int DriverLicenceYear { get; set; }
    public string? Description { get; set; }
    public Location PickUpLocation { get; set; }
    public Location DropofLocation { get; set; }
}
