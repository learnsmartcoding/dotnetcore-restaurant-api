using KarthikTechBlog.Restaurant.API.ViewModel.Get;
using KarthikTechBlog.Restaurant.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.API.ViewModel.Create
{
    public class CreateFoodMenu : FoodMenuViewModel
    {
        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext,
         CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();
            var cuisineService = validationContext.GetService<ICuisineServices>();
            var categoryService = validationContext.GetService<ICategoryService>();


            var category = await categoryService.GetCategoryAsync(CategoryId);
            if (category==null)
            {
                errors.Add(new ValidationResult($"Category id {CategoryId} doesn't exist", new[] { nameof(CategoryId) }));
            }

            var cuisine = await cuisineService.GetCuisineAsync(CuisineId);

            if (cuisine==null)
            {
                errors.Add(new ValidationResult($"Cuisine id {CuisineId} doesn't exist", new[] { nameof(CuisineId) }));                
            }

            if (Price < 5)
            {
                errors.Add(new ValidationResult($"Price cannot be less than $5. Entered price is {Price} ", new[] { nameof(Price) }));
            }

            return errors;

        }

    }
}
