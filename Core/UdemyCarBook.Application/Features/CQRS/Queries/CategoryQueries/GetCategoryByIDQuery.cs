using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Queries.CategoryQueries;
public class GetCategoryByIDQuery
{
    public GetCategoryByIDQuery(int id)
    {
        ID = id;
    }

    public int ID { get; set; }
}
