using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.API
{
    public static class ControllerRoute
    {
        public const string GetCategory = nameof(GetCategory);
        public const string GetAllCategory = nameof(GetAllCategory);
        public const string PostCategory = nameof(PostCategory);
        public const string PutCategory = nameof(PutCategory);
        public const string DeleteCategory = nameof(DeleteCategory);


        public const string GetCuisine = nameof(GetCuisine);
        public const string GetAllCuisine = nameof(GetAllCuisine);
        public const string PostCuisine = nameof(PostCuisine);
        public const string PutCuisine = nameof(PutCuisine);
        public const string DeleteCuisine = nameof(DeleteCuisine);


        public const string GetFoodMenu = nameof(GetFoodMenu);
        public const string GetAllFoodMenuByCuisineId = nameof(GetAllFoodMenuByCuisineId);
        public const string PostFoodMenu = nameof(PostFoodMenu);
        public const string PutFoodMenu = nameof(PutFoodMenu);
        public const string DeleteFoodMenu = nameof(DeleteFoodMenu);
        public const string GetFoodMenuImages = nameof(GetFoodMenuImages);
        public const string UploadFoodMenuImage = nameof(UploadFoodMenuImage);
    }
}
