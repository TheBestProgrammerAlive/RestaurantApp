using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Restaurant.Application.Common.Interfaces;
using Restaurant.Infrastructure.Authentication;
using Restaurant.Infrastructure.Data.Contexts;
using Restaurant.Infrastructure.Data.Repositories;
using Restaurant.Infrastructure.Data.Seeders;
using Restaurant.Infrastructure.Data.UnitsOfWork;
using Restaurant.Infrastructure.Options;


namespace Restaurant.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<ConnectionStringsOptions>(opts =>
        {
            opts.RestaurantConnDb = config.GetConnectionString("RestaurantConnDb");
        });
        services.Configure<JwtOptions>(
            config.GetSection(JwtOptions.SectionName));
        services.AddDbContext<RestaurantContext>((sp, options) =>
        {
            var csOptions = sp.GetRequiredService<IOptions<ConnectionStringsOptions>>().Value;
            if (!string.IsNullOrWhiteSpace(csOptions.RestaurantConnDb))
            {
                options.UseNpgsql(csOptions.RestaurantConnDb);
            }

            options.UseSeeding((ctx, _) => BaseMenuItemDataSeeder.Seed((RestaurantContext)ctx));
            options.UseAsyncSeeding(async (ctx,_, cancellationToken) => await BaseMenuItemDataSeeder.SeedAsync((RestaurantContext)ctx, cancellationToken));
        });

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IMenuItemRepository, MenuItemRepository>();
        services.AddScoped<IIngredientRepository, IngredientRepository>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        return services;
    }
}