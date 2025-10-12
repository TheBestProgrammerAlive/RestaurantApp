using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Infrastructure.Data.Contexts;

public class RestaurantContext(DbContextOptions<RestaurantContext> options) : DbContext(options)
{
    public DbSet<BaseMenuItem> MenuItems { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}