using KarthikTechBlog.Restaurant.API.ViewModel.Get;
using KarthikTechBlog.Restaurant.CrossCutting.Validation;
using KarthikTechBlog.Restaurant.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.API.ViewModel.Update
{
    public class UpdateCuisine : AbstractValidatableObject
    {
        public int Id { get; set; }
     
        [Required]
        [MinLength(10), MaxLength(1000)]
        public string Description { get; set; }

        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext,
         CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();
            var cuisineService = validationContext.GetService<ICuisineServices>();

            var cuisine = await cuisineService.GetCuisineAsync(Id);
            cuisineService.DetachEntity(cuisine);

            if (cuisine == null)
            {
                errors.Add(new ValidationResult($"Cuisine id {Id} does not exist", new[] { nameof(Id) }));
            }

            return errors;

        }

    }
}
