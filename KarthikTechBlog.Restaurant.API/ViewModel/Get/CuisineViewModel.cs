using KarthikTechBlog.Restaurant.CrossCutting.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.API.ViewModel.Get
{
    public class CuisineViewModel: AbstractValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5), MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MinLength(10), MaxLength(1000)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
