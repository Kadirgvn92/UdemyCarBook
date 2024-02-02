using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities;
public class Brand
{
    public Guid BrandID { get; set; }
    public string Name { get; set; }
    public IQueryable<Car> Cars { get; set; }
}
