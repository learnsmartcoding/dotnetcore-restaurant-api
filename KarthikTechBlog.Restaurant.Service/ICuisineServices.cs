using KarthikTechBlog.Restaurant.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.Service
{
    public interface ICuisineServices
    {
        Task<List<Cuisine>> GetCuisineAsync();
        ValueTask<Cuisine> GetCuisineAsync(int id);
        Task<bool> IsCuisineExistAsync(string name);
        Task<bool> CreateCuisineAsync(Cuisine category);
        Task<bool> UpdateCuisineAsync(Cuisine category);
        Task<bool> DeleteCuisineAsync(int id);
        void DetachEntity(Cuisine entityToDetach);
    }
}
