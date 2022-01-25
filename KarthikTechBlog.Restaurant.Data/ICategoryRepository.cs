using KarthikTechBlog.Restaurant.Core;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.Data
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<bool> CommitAsync();
    }
}
