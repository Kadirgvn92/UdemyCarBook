using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UdemyCarBook.DTO.BlogDTOs;
public class CreateBlogDTO
{
    public string Title { get; set; }
    public int AuthorID { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CategoryID { get; set; }
    public string Description { get; set; }
}
