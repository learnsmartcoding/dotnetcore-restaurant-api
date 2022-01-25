using KarthikTechBlog.Restaurant.Core;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.Data
{
    public interface IFoodImagesRepository : IGenericRepository<FoodImages>
    {
        Task<bool> CommitAsync();
    }
}