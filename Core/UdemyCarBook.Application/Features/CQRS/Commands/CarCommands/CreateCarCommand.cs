﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
public class CreateCarCommand
{
    public int BrandID { get; set; }
    public Brand Brands { get; set; }
    public string Model { get; set; }
    public string CoverImageUrl { get; set; }
    public int Km { get; set; }
    public string Transmission { get; set; }
    public short Seats { get; set; }
    public short Luggage { get; set; }
    public string Fuel { get; set; }
    public string BigImageUrl { get; set; }
}
