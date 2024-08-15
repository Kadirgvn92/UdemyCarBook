using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.AppUserInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.AppUserRepositories;
public class AppUserRepository : IAppUserRepository
{
	CarBookContext _carBookContext;
public AppUserRepository(CarBookContext carBookContext)
	{
		_carBookContext = carBookContext;
	}

	public async Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
	{
		var values = _carBookContext.AppUsers.Where(filter).FirstOrDefault();
		return values;
	}

	public async Task<AppRole> GetRoleByFilterAsync(Expression<Func<AppRole, bool>> filter)
	{
		var values = _carBookContext.appRoles.Where(filter).FirstOrDefault();
		return values;
	}
}
