using KarthikTechBlog.Restaurant.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.Service
{
    public interface IFoodMenusServices
    {
        Task<List<FoodMenus>> GetFoodMenusByCuisineIdAsync(int cuisineId);
        ValueTask<FoodMenus> GetFoodMenuAsync(int id);
        Task<bool> IsFoodMenuExistAsync(string name);
        Task<bool> CreateFoodMenuAsync(FoodMenus category);
        Task<bool> UpdateFoodMenuAsync(FoodMenus category);
        Task<bool> DeleteFoodMenuAsync(int id);
        void DetachEntity(FoodMenus entityToDetach);
        Task<bool> CreateFoodMenuImageAsync(byte[] fileBytes, int foodMenuId, string imageName, string mimeType);
        Task<FoodMenus> GetFoodMenuAndImagesAsync(int id);
    }
}
