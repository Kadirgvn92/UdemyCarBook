using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities;
public class Customer
{
    public int CustomerID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public List<RentACarProcess> RentACarProcesses { get; set; }
}
