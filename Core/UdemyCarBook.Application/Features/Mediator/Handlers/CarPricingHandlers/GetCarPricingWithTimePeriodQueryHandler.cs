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
public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
{
	private readonly ICarPricingRepository _carPricingRepository;

	public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository carPricingRepository)
	{
		_carPricingRepository = carPricingRepository;
	}

	public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
	{
		var values = _carPricingRepository.GetCarPricingWithTimePeriod();
		return values.ToList();
	}
}
