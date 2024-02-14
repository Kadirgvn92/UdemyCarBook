using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BannerQueries;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Persistance.Context;
using UdemyCarBook.Persistance.Repositories;

namespace UdemyCarBook.Persistance.Extensions;
public static class Container 
{
    public static void ContainerDependencies(this IServiceCollection services)
    {
        services.AddScoped<CarBookContext>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<GetAboutByIdQueryHandler>();
        services.AddScoped<GetAboutQueryHandler>();
        
        services.AddScoped<CreateAboutCommandHandler>();
        services.AddScoped<UpdateAboutCommandHandler>();
        services.AddScoped<RemoveAboutCommandHandler>();
        
        services.AddScoped<GetBannerByIdQueryHandler>();
        services.AddScoped<GetBannerQueryHandler>();
        services.AddScoped<CreateBannerCommandHandler>();
        services.AddScoped<UpdateBannerCommandHandler>();
        services.AddScoped<RemoveBannerCommandHandler>();

        services.AddScoped<GetBrandQueryHandler>();
        services.AddScoped<GetBrandByIDQueryHandler>();
        services.AddScoped<CreateBrandCommandHandler>();
        services.AddScoped<UpdateBrandCommandHandler>();
        services.AddScoped<RemoveBrandCommandHandler>();

        services.AddScoped<GetCarQueryHandler>();
        services.AddScoped<GetCarByIDQueryHandler>();
        services.AddScoped<CreateCarCommandHandler>();
        services.AddScoped<UpdateCarCommandHandler>();
        services.AddScoped<RemoveCarCommandHandler>();

    }
}
