﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.RentACarRepositories;
public class RentACarRepository : IRentACarRepository
{
    private readonly CarBookContext _context;

    public RentACarRepository(CarBookContext context)
    {
        _context = context;
    }

    public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
    {
        var values = await _context.RentACars.Where(filter).ToListAsync();
        return values;
    }
}
