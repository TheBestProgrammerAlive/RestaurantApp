using Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Restaurant.Api;
using Restaurant.Infrastructure.Data.Contexts;
using Restaurant.Infrastructure.Data.Seeders;

namespace Tests.RestaurantController;

public sealed class TestWebAppFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.ConfigureTestServices(services =>
        {
            // Remove Infrastructure registrations that configure Npgsql provider
            services.RemoveAll<RestaurantContext>();
            services.RemoveAll<DbContextOptions<RestaurantContext>>();
            services.RemoveAll<DbContextOptions>();

            // add SQLite in-memory (relational behavior for EF features)
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            services.AddDbContext<RestaurantContext>(opt =>
                opt.UseSqlite(connection).UseSeeding((ctx, _) => BaseMenuItemDataSeeder.Seed((RestaurantContext)ctx)));

            // build and seed
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<RestaurantContext>();
            db.Database.EnsureCreated();
            db.SaveChanges();
        });
    }
}