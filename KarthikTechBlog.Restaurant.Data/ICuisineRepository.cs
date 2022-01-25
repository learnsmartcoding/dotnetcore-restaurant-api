using KarthikTechBlog.Restaurant.Core;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.Data
{
    public interface ICuisineRepository : IGenericRepository<Cuisine>
    {
        Task<bool> CommitAsync();
    }
}
