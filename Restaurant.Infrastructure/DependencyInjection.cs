using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Infrastructure.Data.Contexts;
using Restaurant.Infrastructure.Data.Repositories;
using Restaurant.Infrastructure.Data.UnitsOfWork;

namespace Restaurant.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<RestaurantContext>(options =>
            options.UseNpgsql(config.GetConnectionString("MenuDbConnection")));
        services.AddScoped<IMenuItemRepository, MenuItemRepository>();
        services.AddScoped<IIngredientRepository, IngredientRepository>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        return services;
    }
}