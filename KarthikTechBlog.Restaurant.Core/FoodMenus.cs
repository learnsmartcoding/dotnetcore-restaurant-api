using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KarthikTechBlog.Restaurant.Core
{
    public class FoodMenus
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
        public short? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int? CuisineId { get; set; }
        public virtual Cuisine Cuisine { get; set; }
        public virtual List<FoodImages> FoodImages { get; set; }
    }
}
