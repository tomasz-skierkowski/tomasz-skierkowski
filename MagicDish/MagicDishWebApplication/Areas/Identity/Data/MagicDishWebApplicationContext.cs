using MagicDishWebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagicDishWebApplication.Data;

public class MagicDishWebApplicationContext : IdentityDbContext<MagicDishWebApplicationUser>
{
    public MagicDishWebApplicationContext(DbContextOptions<MagicDishWebApplicationContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    public DbSet<AvailableProductModel> AvailableProducts { get; set; }
    public DbSet<FoodRepositoryModel> FoodRepositories { get; set; }
    public DbSet<FoodRepositoryProductModel> FoodRepositoryProducts { get; set; }
    public DbSet<RecipesModel> Recipes { get; set; }
    //public DbSet<ProductModel> ProductModel { get; set; }
    //public DbSet<ProductQuantityModel> ProductQuantityModel { get; set; }

}
