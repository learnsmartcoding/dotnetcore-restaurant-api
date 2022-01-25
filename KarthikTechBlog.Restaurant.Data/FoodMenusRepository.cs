using KarthikTechBlog.Restaurant.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.Data
{
    public class FoodMenusRepository : GenericRepository<FoodMenus>, IFoodMenusRepository
    {
        public FoodMenusRepository(RestaurantDbContext context) : base(context)
        {
            Context = context;
        }

        public RestaurantDbContext Context { get; }
        public async Task<bool> CommitAsync()
        {
            return await Context.SaveChangesAsync() > 0;
        }

        public Task<FoodMenus> GetFoodMenuAndImagesAsync(int id)
        {
            return Context.FoodMenus.Include(i => i.FoodImages).FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
