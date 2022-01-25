using KarthikTechBlog.Restaurant.API.ViewModel.Get;
using KarthikTechBlog.Restaurant.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.API.ViewModel.Create
{
    public class CreateCuisine : CuisineViewModel
    {
        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext,
         CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();
            var cuisineService = validationContext.GetService<ICuisineServices>();            

            if (await cuisineService.IsCuisineExistAsync(Name))
            {
                errors.Add(new ValidationResult($"Cuisine name {Name} exist", new[] { nameof(Name) }));                
            }

            return errors;

        }

    }
}
