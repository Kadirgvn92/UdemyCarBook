using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.DTO.CommentDTO;
public class UpdateCommentApprovalDTo
{
    public int CommentId { get; set; }
    public bool IsApproved { get; set; }
}
