using KarthikTechBlog.Restaurant.API.ViewModel.Get;
using KarthikTechBlog.Restaurant.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.API.ViewModel.Update
{
    public class UpdateCategory : CategoryViewModel
    {
        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext,
         CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();
            var categoryService = validationContext.GetService<ICategoryService>();

            var category = await categoryService.GetCategoryAsync(Id);
            categoryService.DetachEntity(category);

            if (category == null)
            {
                errors.Add(new ValidationResult($"Category id {Id} does not exist", new[] { nameof(Id) }));
            }

            return errors;

        }

    }
}
