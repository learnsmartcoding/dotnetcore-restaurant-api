using KarthikTechBlog.Restaurant.CrossCutting.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.API.ViewModel.Get
{
    public class FoodMenuViewModel : AbstractValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MinLength(100), MaxLength(5000)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public short CategoryId { get; set; }   
        public int CuisineId { get; set; }
        public FoodMenuImagesViewModel FoodImage { get; set; }
    }
}
