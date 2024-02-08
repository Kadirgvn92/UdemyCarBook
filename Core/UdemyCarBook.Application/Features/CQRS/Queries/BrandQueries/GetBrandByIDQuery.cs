using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;
public class GetBrandByIDQuery
{
    public GetBrandByIDQuery(int id)
    {
        ID = id;
    }

    public int ID { get; set; }
}
