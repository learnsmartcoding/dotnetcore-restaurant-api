using KarthikTechBlog.Restaurant.Core;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.Data
{
    public interface IFoodMenusRepository : IGenericRepository<FoodMenus>
    {
        Task<bool> CommitAsync();
        Task<FoodMenus> GetFoodMenuAndImagesAsync(int id);
    }
}