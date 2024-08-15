using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.CarResults;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Queries.CarQueries;
public class GetCarDescriptionQuery : IRequest<GetCarDescriptionQueryResult>
{
    public int Id { get; set; }

	public GetCarDescriptionQuery(int id)
	{
		Id = id;
	}
}
