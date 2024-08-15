using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarDescriptonInterfaces;
public interface ICarDescriptionRepository
{
	CarDescription GetCarDescription(int carId);
}
