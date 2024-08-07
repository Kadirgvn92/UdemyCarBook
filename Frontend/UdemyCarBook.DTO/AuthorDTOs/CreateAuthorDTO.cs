using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.DTO.AuthorDTOs;
public class CreateAuthorDTO
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}
