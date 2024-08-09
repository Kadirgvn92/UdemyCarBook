using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.DTO.SocialMediaDTOs;
public class UpdateSocialMediaDTO
{
    public int SocialMediaID { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
}
