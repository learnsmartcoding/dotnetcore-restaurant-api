using KarthikTechBlog.Restaurant.Core;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.Data
{
    public class FoodImagesRepository : GenericRepository<FoodImages>, IFoodImagesRepository
    {
        public FoodImagesRepository(RestaurantDbContext context) : base(context)
        {
            Context = context;
        }

        public RestaurantDbContext Context { get; }
        public async Task<bool> CommitAsync()
        {
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
