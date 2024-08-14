﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
public interface ICarFeatureRepository
{
    List<CarFeature> GetCarFeaturesByCarID(int id);
   void ChangeCarFeatureAvailableToFalse(int id);
   void ChangeCarFeatureAvailableToTrue(int id);
}