﻿using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarInterfaces;
public interface ICarRepository
{
    List<Car> GetCarsListWithBrand();
}
