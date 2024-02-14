using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
public class CreateContactCommandHandler
{
    private readonly IRepository<Contact> _contactRepository;

    public CreateContactCommandHandler(IRepository<Contact> contactRepository)
    {
        _contactRepository = contactRepository;
    }
    public async Task Handle(CreateContactCommand command)
    {
        await _contactRepository.CreateAsync(new Contact
        {
            Name = command.Name,
            Email = command.Email,
            Message = command.Message,
            SendDate = command.SendDate,
            Subject = command.Subject
        });
    }
}
