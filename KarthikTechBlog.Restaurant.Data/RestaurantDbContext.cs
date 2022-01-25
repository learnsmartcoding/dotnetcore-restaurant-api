using KarthikTechBlog.Restaurant.Core;
using Microsoft.EntityFrameworkCore;

namespace KarthikTechBlog.Restaurant.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Cuisine> Cuisine { get; set; }
        public DbSet<FoodMenus> FoodMenus { get; set; }
    }
}
