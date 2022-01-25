using KarthikTechBlog.Restaurant.API.ViewModel.Get;
using KarthikTechBlog.Restaurant.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.API.ViewModel.Create
{
    public class CreateCategory : CategoryViewModel
    {
        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext,
         CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();
            var categoryService = validationContext.GetService<ICategoryService>();            

            if (await categoryService.IsCategoryExistAsync(Name))
            {
                errors.Add(new ValidationResult($"Category name {Name} exist", new[] { nameof(Name) }));                
            }

            return errors;

        }

    }
}
