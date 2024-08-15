using Microsoft.Extensions.DependencyInjection;
using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Application.Interfaces.CarDescriptonInterfaces;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;
using UdemyCarBook.Application.Interfaces.StatisticInterfaces;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarBook.Persistance.Context;
using UdemyCarBook.Persistance.Repositories;
using UdemyCarBook.Persistance.Repositories.BlogRepositories;
using UdemyCarBook.Persistance.Repositories.CarDescriptionRepositories;
using UdemyCarBook.Persistance.Repositories.CarFeatureRepositories;
using UdemyCarBook.Persistance.Repositories.CarPricingRepositories;
using UdemyCarBook.Persistance.Repositories.CarRepositories;
using UdemyCarBook.Persistance.Repositories.CommentRepositories;
using UdemyCarBook.Persistance.Repositories.RentACarRepositories;
using UdemyCarBook.Persistance.Repositories.ReviewRepositories;
using UdemyCarBook.Persistance.Repositories.StatisticRepository;
using UdemyCarBook.Persistance.Repositories.TagCloudRepositories;

namespace UdemyCarBook.Persistance.Extensions;
public static class Container 
{
    public static void ContainerDependencies(this IServiceCollection services)
    {
        

        services.AddScoped<CarBookContext>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
        services.AddScoped(typeof(IBlogRepository), typeof(BlogRepositories));
        services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
        services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
        services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
        services.AddScoped(typeof(IStatisticRepository), typeof(StatisticRepository));
        services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
        services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
        services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
        services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));
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
        services.AddScoped<GetCarWithBrandQueryHandler>();
        services.AddScoped<CreateCarCommandHandler>();
        services.AddScoped<UpdateCarCommandHandler>();
        services.AddScoped<RemoveCarCommandHandler>();
        services.AddScoped<GetLast5CarsWithBrandQueryHandler>();
        services.AddScoped<GetCarWithBrandByIdQueryHandler>();

        services.AddScoped<GetContactQueryHandler>();
        services.AddScoped<GetContactByIdQueryHandler>();
        services.AddScoped<CreateContactCommandHandler>();
        services.AddScoped<UpdateContactCommandHandler>();
        services.AddScoped<RemoveContactCommandHandler>();

        services.AddScoped<GetCategoryQueryHandler>();
        services.AddScoped<GetCategoryByIDQueryHandler>();
        services.AddScoped<CreateCategoryCommandHandler>();
        services.AddScoped<UpdateCategoryCommandHandler>();
        services.AddScoped<RemoveCategoryCommandHandler>();
    }
}
