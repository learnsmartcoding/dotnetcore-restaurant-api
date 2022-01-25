using KarthikTechBlog.Restaurant.API.ViewModel.Create;
using KarthikTechBlog.Restaurant.CrossCutting.Validation;
using KarthikTechBlog.Restaurant.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.API.ViewModel.Update
{
    public class UpdateFoodMenu : CreateFoodMenu
    {
        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(
             ValidationContext validationContext,
             CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();

            var foodMenusServices = validationContext.GetService<IFoodMenusServices>();

            var foodMenuEntity = await foodMenusServices.GetFoodMenuAsync(Id);

            if (foodMenuEntity == null)
            {
                errors.Add(new ValidationResult($"No such food menu id {Id} exist", new[] { nameof(Id) }));
                return errors;
            }

            errors.AddRange(await base.ValidateAsync(validationContext, cancellation));

            return errors;
        }

    }
}
