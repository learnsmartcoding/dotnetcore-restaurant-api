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
    public class FoodMenusServices : IFoodMenusServices
    {
        public FoodMenusServices(ILogger<FoodMenusServices> logger,
           IFoodMenusRepository foodMenusRepository)
        {
            Logger = logger;
            FoodMenusRepository = foodMenusRepository;
        }

        public ILogger<FoodMenusServices> Logger { get; }
        public IFoodMenusRepository FoodMenusRepository { get; }

        public async Task<bool> CreateFoodMenuAsync(FoodMenus category)
        {
            FoodMenusRepository.Add(category);
            return await FoodMenusRepository.CommitAsync();
        }

        public async Task<bool> DeleteFoodMenuAsync(int id)
        {
            FoodMenusRepository.Delete(id);
            return await FoodMenusRepository.CommitAsync();
        }

        public void DetachEntity(FoodMenus entityToDetach)
        {
            FoodMenusRepository.DetachEntities(entityToDetach);
        }

        public Task<List<FoodMenus>> GetFoodMenusByCuisineIdAsync(int cuisineId)
        {
            return FoodMenusRepository.GetAsync(c => c.IsActive && c.CuisineId == cuisineId);
        }

        public ValueTask<FoodMenus> GetFoodMenuAsync(int id)
        {
            return FoodMenusRepository.GetByIdAsync(id);
        }

        public async Task<bool> IsFoodMenuExistAsync(string name)
        {
            var category = await FoodMenusRepository.GetAsync(g => g.Name == name);
            return category.Any();
        }

        public async Task<bool> UpdateFoodMenuAsync(FoodMenus category)
        {
            FoodMenusRepository.Update(category);
            return await FoodMenusRepository.CommitAsync();
        }

        public async Task<bool> CreateFoodMenuImageAsync(byte[] fileBytes, int foodMenuId, string imageName, string mimeType)
        {
            FoodImages foodImages = new FoodImages()
            {
                FoodMenusId = foodMenuId,
                Image = fileBytes,
                Mime = mimeType,
                ImageName = imageName,
                IsActive = true
            };
            var foodMenu = await FoodMenusRepository.GetByIdAsync(foodMenuId);
            foodMenu.FoodImages = new List<FoodImages>() { foodImages };

            return await FoodMenusRepository.CommitAsync();
        }

        public Task<FoodMenus> GetFoodMenuAndImagesAsync(int id)
        {
            return FoodMenusRepository.GetFoodMenuAndImagesAsync(id);
        }
    }
}
