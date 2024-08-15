using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
public class GetCarWithBrandByIdQuery
{
	public GetCarWithBrandByIdQuery(int iD)
	{
		ID = iD;
	}

	public int ID { get; set; }
}
