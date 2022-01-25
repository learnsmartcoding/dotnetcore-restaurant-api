using KarthikTechBlog.Restaurant.Core;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.Data
{
    public class CuisineRepository : GenericRepository<Cuisine>, ICuisineRepository
    {
        public CuisineRepository(RestaurantDbContext context) : base(context)
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
