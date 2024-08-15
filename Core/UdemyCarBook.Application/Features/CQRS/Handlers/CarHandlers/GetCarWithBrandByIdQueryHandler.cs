using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
public class GetCarWithBrandByIdQueryHandler
{
	private readonly ICarRepository _carRepository;

	public GetCarWithBrandByIdQueryHandler(ICarRepository carRepository)
	{
		_carRepository = carRepository;
	}
	public async Task<GetCarWithBrandByIdQueryResult> Handle(GetCarWithBrandByIdQuery query)
	{
		var values = _carRepository.GetCarWithBrandByID(query.ID);
		return new GetCarWithBrandByIdQueryResult
		{
			BigImageUrl = values.BigImageUrl,
			BrandID = values.BrandID,
			CarID = values.CarID,
			BrandName = values.Brands.Name,
			CoverImageUrl = values.CoverImageUrl,
			Fuel = values.Fuel,
			Km = values.Km,
			Luggage = values.Luggage,
			Model = values.Model,
			Seats = values.Seats,
			Transmission = values.Transmission
		};
	}
}
