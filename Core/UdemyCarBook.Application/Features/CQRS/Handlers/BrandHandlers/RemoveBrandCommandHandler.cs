using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
public class RemoveBrandCommandHandler
{
    private readonly IRepository<Brand> _brandRepository;

    public RemoveBrandCommandHandler(IRepository<Brand> brandRepository)
    {
        _brandRepository = brandRepository;
    }
    public async Task Handle(RemoveBrandCommand commandHandler)
    {
        var values = await _brandRepository.GetByIDAsync(commandHandler.ID);
        await _brandRepository.DeleteAsync(values);
    }
}
