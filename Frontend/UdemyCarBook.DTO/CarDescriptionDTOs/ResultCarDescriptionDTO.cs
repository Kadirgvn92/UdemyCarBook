using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.DTO.CarDescriptionDTOs;
public class ResultCarDescriptionDTO
{
    public int CarDescriptionID { get; set; }
    public int CarID { get; set; }
    public string Details { get; set; }
}
