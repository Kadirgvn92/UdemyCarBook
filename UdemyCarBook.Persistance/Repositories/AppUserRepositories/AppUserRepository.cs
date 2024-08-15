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
public class AppUserRepository 
{
	CarBookContext _carBookContext;
	public AppUserRepository(CarBookContext carBookContext)
	{
		_carBookContext = carBookContext;
	}
}
