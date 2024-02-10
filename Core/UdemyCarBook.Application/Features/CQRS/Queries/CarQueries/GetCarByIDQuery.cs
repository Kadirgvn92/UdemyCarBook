using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
public class GetCarByIDQuery
{
    public GetCarByIDQuery(int ıD)
    {
        ID = ıD;
    }

    public int ID { get; set; }
}
