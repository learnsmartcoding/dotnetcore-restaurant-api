using KarthikTechBlog.Restaurant.Core;
using KarthikTechBlog.Restaurant.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.Service
{
    public class CategoryService : ICategoryService
    {
        public CategoryService(ILogger<CategoryService> logger,
            ICategoryRepository categoryRepository)
        {
            Logger = logger;
            CategoryRepository = categoryRepository;
        }

        public ILogger<CategoryService> Logger { get; }
        public ICategoryRepository CategoryRepository { get; }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            CategoryRepository.Add(category);
            return await CategoryRepository.CommitAsync();
        }

        public async Task<bool> DeleteCategoryAsync(short id)
        {
            CategoryRepository.Delete(id);
            return await CategoryRepository.CommitAsync();
        }

        public void DetachEntity(Category entityToDetach)
        {
            CategoryRepository.DetachEntities(entityToDetach);
        }

        public Task<List<Category>> GetCategoriesAsync()
        {
            return CategoryRepository.GetAsync(c => c.IsActive);
        }

        public ValueTask<Category> GetCategoryAsync(short id)
        {
            return CategoryRepository.GetByIdAsync(id);
        }

        public async Task<bool> IsCategoryExistAsync(string name)
        {
            var category = await CategoryRepository.GetAsync(g => g.Name == name);
            return category.Any();
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            CategoryRepository.Update(category);
            return await CategoryRepository.CommitAsync();
        }
    }
}
