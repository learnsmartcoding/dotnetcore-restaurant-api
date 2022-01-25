using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KarthikTechBlog.Restaurant.Core
{
    /// <summary>
    /// Category could be Soft Drinks, 
    /// </summary>
    public class Category
    {
        public short Id { get; set; }
        [Required]
        [MinLength(5), MaxLength(25)]
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
