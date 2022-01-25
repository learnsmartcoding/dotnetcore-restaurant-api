using AutoMapper;
using KarthikTechBlog.Restaurant.API.ViewModel.Create;
using KarthikTechBlog.Restaurant.API.ViewModel.Get;
using KarthikTechBlog.Restaurant.API.ViewModel.Update;
using KarthikTechBlog.Restaurant.Core;
using System;

namespace KarthikTechBlog.Restaurant.API
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CreateCategory, Category>();
            CreateMap<UpdateCategory, Category>();

            CreateMap<Cuisine, CuisineViewModel>();
            CreateMap<CreateCuisine, Cuisine>();
            CreateMap<UpdateCuisine, Cuisine>();

            CreateMap<FoodMenus, FoodMenuViewModel>();
            CreateMap<CreateFoodMenu, FoodMenus>();
            CreateMap<UpdateFoodMenu, FoodMenus>();


            CreateMap<FoodImages, FoodMenuImagesViewModel>(MemberList.None)
                .AfterMap((s, d) => d.Base64Image = Convert.ToBase64String(s.Image));

        }

    }
}

