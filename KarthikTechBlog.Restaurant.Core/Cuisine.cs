using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KarthikTechBlog.Restaurant.Core
{
    public class Cuisine
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5), MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MinLength(10), MaxLength(8000)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<FoodMenus> FoodMenus { get; set; }
    }
}
