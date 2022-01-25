using KarthikTechBlog.Restaurant.Core;
using KarthikTechBlog.Restaurant.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.Service
{
    public class CuisineServices : ICuisineServices
    {
        public CuisineServices(ILogger<CuisineServices> logger,
           ICuisineRepository cuisineRepository)
        {
            Logger = logger;
            CuisineRepository = cuisineRepository;
        }

        public ILogger<CuisineServices> Logger { get; }
        public ICuisineRepository CuisineRepository { get; }

        public async Task<bool> CreateCuisineAsync(Cuisine category)
        {
            CuisineRepository.Add(category);
            return await CuisineRepository.CommitAsync();
        }

        public async Task<bool> DeleteCuisineAsync(int id)
        {
            CuisineRepository.Delete(id);
            return await CuisineRepository.CommitAsync();
        }

        public void DetachEntity(Cuisine entityToDetach)
        {
            CuisineRepository.DetachEntities(entityToDetach);
        }

        public Task<List<Cuisine>> GetCuisineAsync()
        {
            return CuisineRepository.GetAsync(c => c.IsActive);
        }

        public ValueTask<Cuisine> GetCuisineAsync(int id)
        {
            return CuisineRepository.GetByIdAsync(id);
        }

        public async Task<bool> IsCuisineExistAsync(string name)
        {
            var category = await CuisineRepository.GetAsync(g => g.Name == name);
            return category.Any();
        }

        public async Task<bool> UpdateCuisineAsync(Cuisine category)
        {
            CuisineRepository.Update(category);
            return await CuisineRepository.CommitAsync();
        }
    }
}
