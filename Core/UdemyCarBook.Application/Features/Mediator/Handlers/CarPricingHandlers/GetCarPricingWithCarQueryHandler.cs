using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarPricingHandlers;
public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
{
	private readonly ICarPricingRepository _carPricingRepository;

	public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
	{
		_carPricingRepository = carPricingRepository;
	}

	public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
	{
		var values = _carPricingRepository.GetCarPricingWithCar();
		return values.Select(x => new GetCarPricingWithCarQueryResult
		{
			CarID = x.CarID,
			Amount = x.Amount,
			Brand = x.Car.Brands.Name,
			CoverImageUrl = x.Car.CoverImageUrl,
			Model = x.Car.Model,
			CarPricingID = x.CarPricingID
		}).ToList();
	}
}
