﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
public class UpdateBrandCommandHandler
{
    private readonly IRepository<Brand> _brandRepository;

    public UpdateBrandCommandHandler(IRepository<Brand> brandRepository)
    {
        _brandRepository = brandRepository;
    }
    public async Task Handle (UpdateBrandCommand command)
    {
        var values = await _brandRepository.GetByIDAsync(command.BrandID);
        values.Name = command.Name;
        await _brandRepository.UpdateAsync(values);
    }
}
