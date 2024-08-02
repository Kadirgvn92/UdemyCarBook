using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
public class GetCarWithPricingQueryHandler
{
	private readonly ICarRepository _carRepository;

	public GetCarWithPricingQueryHandler(ICarRepository carRepository)
	{
		_carRepository = carRepository;
	}

	public List<GetCarWithPricingQueryResult> Handle()
	{
		var values = _carRepository.GetCarsWithPricings();
		return values.Select(x => new GetCarWithPricingQueryResult
		{
			BigImageUrl = x.BigImageUrl,
			BrandID = x.BrandID,
			BrandName = x.Brands.Name,
			CarID = x.CarID,
			CoverImageUrl = x.CoverImageUrl,
			Fuel = x.Fuel,
			Km = x.Km,
			Luggage = x.Luggage,
			Model = x.Model
		}).ToList();
	}
}
