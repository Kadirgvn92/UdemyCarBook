using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarDescriptonInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.CarDescriptionRepositories;
public class CarDescriptionRepository : ICarDescriptionRepository
{
	private readonly CarBookContext _context;

	public CarDescriptionRepository(CarBookContext context)
	{
		_context = context;
	}

	public CarDescription GetCarDescription(int carId)
	{
		var values = _context.CarDescriptions.Where(x => x.CarID  == carId).FirstOrDefault();
		return values;
	}
}
