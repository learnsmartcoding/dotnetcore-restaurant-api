using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.API.ViewModel.Get
{
    public class FoodMenuImagesViewModel
    {
        public int Id { get; set; }
        public string Base64Image { get; set; }
        public string Mime { get; set; }
        public string ImageName { get; set; }
        public int FoodMenusId { get; set; }
    }
}
