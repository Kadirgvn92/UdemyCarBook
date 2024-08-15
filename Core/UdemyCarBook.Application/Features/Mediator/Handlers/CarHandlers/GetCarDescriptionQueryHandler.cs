using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarDescriptonInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarHandlers;
public class GetCarDescriptionQueryHandler : IRequestHandler<GetCarDescriptionQuery, GetCarDescriptionQueryResult>
{
	private readonly ICarDescriptionRepository _carRepository;

	public GetCarDescriptionQueryHandler(ICarDescriptionRepository carRepository)
	{
		_carRepository = carRepository;
	}

	public async Task<GetCarDescriptionQueryResult> Handle(GetCarDescriptionQuery request, CancellationToken cancellationToken)
	{
		var values  = _carRepository.GetCarDescription(request.Id);
		return new GetCarDescriptionQueryResult
		{
			CarDescriptionID = values.CarDescriptionID,
			CarID = values.CarID,
			Details = values.Details,
		};
	}
}
