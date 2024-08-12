using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands;
public class CreateCommentCommand : IRequest
{
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
    public string Mail { get; set; }
    public bool IsApproved { get; set; }
    public int BlogID { get; set; }
}
